using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RegistryEditor.Helper;
using RegistryEditor.Models;
using System.Threading;

namespace RegistryEditor
{
    public partial class MainWindow : Form
    {
        private DateTime startDateTime
        {
            get { return startDate.Value + startTime.Value.TimeOfDay; }
        }

        private DateTime endDateTime
        {
            get { return endDate.Value + endTime.Value.TimeOfDay; }
        }

        private int _threadSafeMutexForCheckedBackValue = 0;
        private bool ThreadSafeMutexForChecked
        {
            get { return (Interlocked.CompareExchange(ref _threadSafeMutexForCheckedBackValue, 1, 1) == 1); }
            set
            {
                if (value) Interlocked.CompareExchange(ref _threadSafeMutexForCheckedBackValue, 1, 0);
                else Interlocked.CompareExchange(ref _threadSafeMutexForCheckedBackValue, 0, 1);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void DisplayInformation(string message)
        {
            MessageBox.Show(message, Constants.InformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Initialize()
        {
            this.Text = string.Format(Constants.MainWindowTitleFormat, Constants.RootRegistryPath);
            tbBackupFolder.Text = ConfigurationHelper.Configuration.DefaultBackupFolder;
            Reload();
            SetTreeViewEnabled(radioBtnGroupRegistry.Checked);
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
            SetLogButtonStates();
            ResetDates();
            RegistryKeysOperation.SetLogParameters(IsChangesAvailableToReset(registryTreeView.Nodes));
        }

        /// <summary>
        /// Set datetime initial values.
        /// </summary>
        private void ResetDates()
        {
            var nextDay = DateTime.Today.AddDays(1);
            startDate.MaxDate = endDate.MaxDate = nextDay;

            var now = DateTime.Now;
            now = now.AddSeconds(-now.Second);
            startDate.Value = now.AddHours(-1).Date;
            startTime.Value = now.AddHours(-1);
            endDate.Value = now.Date;
            endTime.Value = now;
        }

        private void ReloadGroupRegistry()
        {
            groupRegistryTreeView.Nodes.Clear();
            foreach (var registryGroup in ConfigurationHelper.Configuration.Groups)
            {
                var node = new TreeNode(registryGroup.Name);
                LoadRegistryGroupTree(node, registryGroup);
                node.Checked = node.Nodes.AsParallel().OfType<TreeNode>().Where(n => n.ForeColor != Color.Red).All(n => n.Checked);
                groupRegistryTreeView.Nodes.Add(node);
            }
            groupRegistryTreeView.CollapseAll();
        }

        private void LoadRegistryGroupTree(TreeNode node, RegistryGroup registryGroup)
        {
            node.Tag = registryGroup;
            foreach (var registry in registryGroup.RegistryValues)
            {
                var registryNode = new TreeNode(registry.Name);
                SetNodeState(registryNode, registry.Path);
                registry.IsChecked = registryNode.Checked;
                registry.IsMissing = registryNode.ForeColor == Color.Red;
                registryNode.Tag = registry;
                node.Nodes.Add(registryNode);
            }
        }

        private void Reload()
        {
            SetLoading(true);
            ReloadRegistryTree();
            ReloadGroupRegistry();
            SetLoading(false);
        }

        /// <summary>
        /// To indicate data loading when UI refresh in progress.
        /// </summary>
        /// <param name="displayLoader"></param>
        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.Default;
                });
            }
        }

        private void ReloadRegistryTree()
        {
            registryTreeView.Nodes.Clear();
            LoadRegistryNodes(Constants.RootRegistryPath, registryTreeView.Nodes);
            registryTreeView.ExpandAll();
        }

        public void LoadRegistryNodes(string path, TreeNodeCollection nodes)
        {
            foreach (var key in RegistryKeysOperation.GetSubKeys(path))
            {
                var childPath = path + "\\" + key;
                var node = new TreeNode(key);
                SetNodeState(node, childPath);
                node.Tag = new RegistryEntry { IsChecked = node.Checked, Name = key };
                //Enable this to load multilevel registry entries under Log.
                //LoadRegistryNodes(childPath, node.Nodes);
                nodes.Add(node);
            }
        }

        /// <summary>
        /// Set individual tree node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="childPath"></param>
        private void SetNodeState(TreeNode node, string childPath)
        {
            var registryState = RegistryKeysOperation.GetValue(childPath);
            switch (registryState)
            {
                case RegistryState.Disabled:
                    {
                        break;
                    }
                case RegistryState.Enabled:
                    {
                        node.Checked = true;
                        break;
                    }
                case RegistryState.None:
                    {
                        node.ForeColor = Color.Red;
                        break;
                    }
            }
        }

        private void SetCheckedNodeStatus(TreeNode checkedNode, bool newValue)
        {
            foreach (TreeNode node in checkedNode.Nodes)
            {
                SetCheckedNodeStatus(node, newValue);
            }
            checkedNode.Checked = newValue;
            if (checkedNode.Tag is RegistryEntry)
            {
                var re = checkedNode.Tag as RegistryEntry;
                if (re.IsChecked != newValue)
                {
                    checkedNode.ForeColor = Color.Blue;
                }
                else
                {
                    checkedNode.ForeColor = re.IsMissing ? Color.Red : Color.Black;
                }

                if (checkedNode.Parent != null)
                {
                    checkedNode.Parent.Checked = checkedNode.Parent.Nodes.AsParallel().OfType<TreeNode>()
                        .Where(n => n.ForeColor != Color.Red).All(n => n.Checked);
                    checkedNode.Parent.ForeColor =
                        checkedNode.Parent.Nodes.AsParallel().Cast<TreeNode>().Any(n => n.ForeColor == Color.Blue)
                            ? Color.Blue
                            : Color.Black;
                }
            }
            else
            {
                checkedNode.ForeColor = checkedNode.Nodes.AsParallel().Cast<TreeNode>().Any(n => n.ForeColor == Color.Blue) ? Color.Blue : Color.Black;
            }
        }

        private bool MapRegistry(TreeNode selectedNode)
        {
            var result = false;
            var registryGroup = (RegistryGroup)selectedNode.Tag;
            var registryPicker = new RegistryPicker(selectedNode.FullPath, registryTreeView.Nodes,
                registryGroup.RegistryValues.Select(x => x.Path.Substring(x.Path.LastIndexOf('\\') + 1)).ToList());
            registryPicker.ShowDialog();
            if (registryPicker.SelectedRegistryList.Count > 0)
            {
                foreach (var newRegistry in registryPicker.SelectedRegistryList)
                {
                    var newNode = new TreeNode(newRegistry);
                    selectedNode.Nodes.Add(newNode);
                    var newRegistryEntry = new RegistryEntry { Name = newRegistry };
                    newNode.Tag = newRegistry;
                    registryGroup.RegistryValues.Add(newRegistryEntry);
                }
                result = true;
            }
            return result;
        }

        private void SetRegistryButtonStates(bool isGroupRegistryTree)
        {
            if (isGroupRegistryTree)
            {
                var selectedNode = groupRegistryTreeView.SelectedNode;
                if (selectedNode != null)
                {
                    var isReadonly =
                        ((selectedNode.Level == 0 ? selectedNode.Tag : selectedNode.Parent.Tag) as RegistryGroup)
                        .IsReadOnly;
                    if (isReadonly)
                    {
                        EnableEditButtons(false);
                    }
                    else
                    {
                        EnableEditButtons(true);
                        if (selectedNode.Level != 0)
                        {
                            btnRename.Enabled = btnMapRegistry.Enabled = false;
                        }
                    }
                }
                else
                {
                    EnableEditButtons(false);
                }
            }
            else
            {
                EnableEditButtons(false);
            }
            btnNewGroup.Enabled = isGroupRegistryTree;
            btnReset.Enabled = btnApplyChanges.Enabled = IsChangesAvailableToApply(isGroupRegistryTree ? groupRegistryTreeView.Nodes : registryTreeView.Nodes);
            btnClearAll.Enabled = IsChangesAvailableToReset(isGroupRegistryTree ? groupRegistryTreeView.Nodes : registryTreeView.Nodes);
        }

        public void EnableEditButtons(bool value)
        {
            btnDelete.Enabled = btnMapRegistry.Enabled = btnRename.Enabled = value;
        }

        /// <summary>
        /// Identify whether changes available to reset.
        /// </summary>
        /// <param name="tv">node</param>
        /// <returns></returns>
        private bool IsChangesAvailableToReset(TreeNodeCollection tv)
        {
            foreach (TreeNode node in tv)
            {
                if (node.Tag is RegistryEntry && ((RegistryEntry)node.Tag).IsChecked)
                {
                    return true;
                }
                else if (IsChangesAvailableToReset(node.Nodes))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Identify whether changes available to Save.
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        private bool IsChangesAvailableToApply(TreeNodeCollection tv)
        {
            foreach (TreeNode node in tv)
            {
                if (node.Tag is RegistryEntry)
                {
                    var re = node.Tag as RegistryEntry;
                    if (re.IsChecked != node.Checked)
                        return true;
                }
                else if (IsChangesAvailableToApply(node.Nodes))
                {
                    return true;
                }
            }
            return false;
        }

        private TreeNode CreateNewGroup(InputTextForm inputForm)
        {
            var newNode = new TreeNode(inputForm.InputText);
            groupRegistryTreeView.Nodes.Add(newNode);
            var newGroup = new RegistryGroup(inputForm.InputText, false);
            newNode.Tag = newGroup;
            ConfigurationHelper.Configuration.Groups.Add(newGroup);
            ConfigurationHelper.Save();
            return newNode;
        }

        private bool ShowWarning(string title)
        {
            var res = MessageBox.Show(title, Constants.WarningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return res == DialogResult.Yes;
        }

        private bool IsCriticalNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode eNode in nodes)
            {
                if (eNode.Tag is RegistryEntry)
                {
                    var re = (RegistryEntry)eNode.Tag;
                    if (re != null && re.IsChecked != eNode.Checked && !string.IsNullOrWhiteSpace(re.Path) && Constants
                            .CriticalKeysForWarning.Split(',').Any(val =>
                                re.Path.EndsWith(val.Trim(), StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return true;
                    }
                }
                if (IsCriticalNode(eNode.Nodes))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set all child values of single node.
        /// </summary>
        /// <param name="nodes"></param>
        private void SetValues(TreeNodeCollection nodes)
        {
            foreach (TreeNode eNode in nodes)
            {
                if (eNode.Tag is RegistryEntry)
                {
                    var re = (RegistryEntry)eNode.Tag;
                    if (re != null && re.IsChecked != eNode.Checked && !string.IsNullOrWhiteSpace(re.Path))
                    {
                        RegistryKeysOperation.SetRegistryValue(re.Path, eNode.Checked);
                    }
                }
                SetValues(eNode.Nodes);
            }
        }

        /// <summary>
        /// Set all the node values.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="value"></param>
        private void SetAllValues(TreeNodeCollection nodes, bool value)
        {
            foreach (TreeNode eNode in nodes)
            {
                if (eNode.Tag is RegistryEntry)
                {
                    var re = (RegistryEntry)eNode.Tag;
                    if (re != null && !string.IsNullOrWhiteSpace(re.Path))
                    {
                        RegistryKeysOperation.SetRegistryValue(re.Path, value);
                    }
                }
                SetAllValues(eNode.Nodes, value);
            }
        }

        /// <summary>
        /// Set tree enable disable states.
        /// </summary>
        /// <param name="isGroupRegistryTree"></param>
        private void SetTreeViewEnabled(bool isGroupRegistryTree)
        {
            if (isGroupRegistryTree)
            {
                SetTreeState(registryTreeView, false);
                SetTreeState(groupRegistryTreeView, true);
            }
            else
            {
                SetTreeState(registryTreeView, true);
                SetTreeState(groupRegistryTreeView, false);
            }
            Reload();
            SetRegistryButtonStates(isGroupRegistryTree);
        }

        /// <summary>
        /// Set tree enable disable look.
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="enabled"></param>
        private void SetTreeState(CustomTreeView tv, bool enabled)
        {
            tv.Enabled = enabled;
            tv.BackColor = enabled ? Color.White : Color.LightGray;
            tv.LineColor = enabled ? Color.Black : Color.Gray;
            tv.ForeColor = enabled ? Color.Black : Color.Gray;
        }

        /// <summary>
        /// Set log button states.
        /// </summary>
        private void SetLogButtonStates()
        {
            var backupFolderExists = Directory.Exists(tbBackupFolder.Text);
            if (btnOpenFolder.Enabled)
                btnOpenFolder.Enabled = backupFolderExists;
            btnBackupLog.Enabled = backupFolderExists && startDateTime < endDateTime;
        }

        /// <summary>
        /// Get log destination folder path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetLogDestinationFolder(string path)
        {
            return Path.Combine(tbBackupFolder.Text,
                string.Format(Constants.BackupLogsFolder,
                    startDateTime.ToString(Constants.BackupDateTimeFormat),
                    endDateTime.ToString(Constants.BackupDateTimeFormat)),
                Path.GetFileName(path));
        }

        #region EventHandlers

        private void groupRegistryTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!ThreadSafeMutexForChecked)
            {
                ThreadSafeMutexForChecked = true;
                var checkedNode = e.Node;
                SetCheckedNodeStatus(checkedNode, checkedNode.Checked);
                ThreadSafeMutexForChecked = false;
                SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            var inputForm = new InputTextForm(Constants.AddNewGroupTitle, string.Empty);
            inputForm.ShowDialog();
            if (!string.IsNullOrEmpty(inputForm.InputText))
            {
                if (groupRegistryTreeView.Nodes.AsParallel().Cast<TreeNode>().Any(node =>
                        node.Text.Equals(inputForm.InputText, StringComparison.InvariantCultureIgnoreCase)))
                {
                    DisplayInformation(string.Format(Constants.GroupRegistryAlreadyExistsMessage, inputForm.InputText));
                }
                else
                {
                    var newGroupTreeNode = CreateNewGroup(inputForm);
                    MapRegistry(newGroupTreeNode);
                    Reload();
                    SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            var selectedNode = groupRegistryTreeView.SelectedNode;
            var registryGroup = (RegistryGroup)selectedNode.Tag;

            var inputForm = new InputTextForm(Constants.NewGroupTitle, registryGroup.Name);
            inputForm.ShowDialog();
            if (!string.IsNullOrEmpty(inputForm.InputText))
            {
                if (groupRegistryTreeView.Nodes.AsParallel().Cast<TreeNode>().Any(node => node != selectedNode && node.Text.Equals(inputForm.InputText, StringComparison.InvariantCultureIgnoreCase)))
                {
                    DisplayInformation(string.Format(Constants.GroupRegistryAlreadyExistsMessage, inputForm.InputText));
                }
                else
                {
                    registryGroup.Name = selectedNode.Text = inputForm.InputText;
                    ConfigurationHelper.Save();
                    Reload();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedNode = groupRegistryTreeView.SelectedNode;
            if (selectedNode.Level == 0)
            {
                if (ShowWarning(string.Format(Constants.GroupRegistryDeleteConfirmationMessage, selectedNode.Text)))
                {
                    var registryGroup = (RegistryGroup)selectedNode.Tag;
                    selectedNode.Nodes.Remove(selectedNode);
                    ConfigurationHelper.Configuration.Groups.Remove(registryGroup);
                }
            }
            else
            {
                var registryEntry = (RegistryEntry)selectedNode.Tag;
                ((RegistryGroup)selectedNode.Parent.Tag).RegistryValues.Remove(registryEntry);
                selectedNode.Parent.Nodes.Remove(selectedNode);
            }
            ConfigurationHelper.Save();
            Reload();
        }

        private void groupRegistryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetRegistryButtonStates(true);
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            var tv = radioBtnGroupRegistry.Checked ? groupRegistryTreeView : registryTreeView;
            if (IsCriticalNode(tv.Nodes) &&
                !ShowWarning(Constants.DatabaseWarningMessage))
            {
                return;
            }
            SetValues(tv.Nodes);
            Reload();
            RegistryKeysOperation.SetLogParameters(IsChangesAvailableToReset(registryTreeView.Nodes));
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
        }

        private void radioBtnGroupRegistry_CheckedChanged(object sender, EventArgs e)
        {
            SetTreeViewEnabled((sender as RadioButton).Checked);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            var tv = radioBtnGroupRegistry.Checked ? groupRegistryTreeView : registryTreeView;
            if (!ShowWarning(Constants.ClearAllWarningMessage))
            {
                return;
            }
            SetAllValues(tv.Nodes, false);
            RegistryKeysOperation.SetLogParameters(false);
            Reload();
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbBackupFolder.Text = folderBrowserDialog.SelectedPath;
                SetLogButtonStates();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(tbBackupFolder.Text);
        }

        private void registryTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!ThreadSafeMutexForChecked)
            {
                ThreadSafeMutexForChecked = true;
                var checkedNode = e.Node;
                SetCheckedNodeStatus(checkedNode, checkedNode.Checked);
                ThreadSafeMutexForChecked = false;
                SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reload();
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
        }

        private void btnMapRegistry_Click(object sender, EventArgs e)
        {
            var selectedNode = groupRegistryTreeView.SelectedNode;
            if (MapRegistry(selectedNode))
            {
                ConfigurationHelper.Save();
                Reload();
            }
        }

        private void tbBackupFolder_TextChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void btnBackupLog_Click(object sender, EventArgs e)
        {
            btnOpenFolder.Enabled = true;
            btnBackupLog.Enabled = false;
            var logPathFromRegistry = RegistryKeysOperation.GetLogFilePath();
            var logPathFromConfig = ConfigurationHelper.Configuration.LogFolderPath;

            LogFilesHelper.Copy(logPathFromRegistry, GetLogDestinationFolder(logPathFromRegistry), startDateTime, endDateTime, Constants.LogFileFilter);
            LogFilesHelper.Copy(logPathFromConfig, GetLogDestinationFolder(logPathFromConfig), startDateTime, endDateTime, Constants.LogFileFilter);
            if (MessageBox.Show(Constants.BackupCompletedMessage, Constants.BackupCompletedTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start(GetLogDestinationFolder(string.Empty));
            }
        }

        private void groupRegistryTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            var selectedNode = groupRegistryTreeView.SelectedNode;
            if (e.Node.Level == 0)
            {
                if (e.Node.Nodes.Count == 0)
                    e.Cancel = true;
            }
            else if (e.Action != TreeViewAction.Unknown)
            {
                e.Cancel = true;
            }
        }

        private void endTime_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void startTime_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
