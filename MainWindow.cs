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


        private int _ThreadSafeMutexForCheckedBackValue = 0;
        public bool ThreadSafeMutexForChecked
        {
            get { return (Interlocked.CompareExchange(ref _ThreadSafeMutexForCheckedBackValue, 1, 1) == 1); }
            set
            {
                if (value) Interlocked.CompareExchange(ref _ThreadSafeMutexForCheckedBackValue, 1, 0);
                else Interlocked.CompareExchange(ref _ThreadSafeMutexForCheckedBackValue, 0, 1);
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
            this.Text = string.Format(Constants.MainWindowTitleFormat, this.Text, Constants.RootRegistryPath);
            Reload();
            SetTreeViewEnabled(radioBtnGroupRegistry.Checked);
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
            SetLogButtonStates();
            RegistryKeysOperation.SetLogParameters(IsChangesAvailableToClear(registryTreeView.Nodes));
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
                var registryNode = new TreeNode(registry.Path);
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
                node.Tag = new RegistryEntry { IsChecked = node.Checked, Path = childPath };
                //Enable this to load multilevel registry entries under Log.
                //LoadRegistryNodes(childPath, node.Nodes);
                nodes.Add(node);
            }
        }

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
        }

        private void btnMapRegistry_Click(object sender, EventArgs e)
        {
            var selectedNode = groupRegistryTreeView.SelectedNode;
            var registryGroup = (RegistryGroup)selectedNode.Tag;
            var registryPicker = new RegistryPicker(registryTreeView.Nodes, registryGroup.RegistryValues.Select(x => x.Path.Substring(x.Path.LastIndexOf('\\') + 1)).ToList());
            registryPicker.ShowDialog();
            if (!string.IsNullOrEmpty(registryPicker.SelectedRegistry))
            {
                var newKey = Constants.RootRegistryPath + "\\" +
                             registryPicker.SelectedRegistry;
                if (selectedNode.Nodes.AsParallel().Cast<TreeNode>().Any(node => (node.Tag as RegistryEntry).Path.Equals(newKey, StringComparison.InvariantCultureIgnoreCase)))
                {
                    DisplayInformation(string.Format(Constants.RegistryAlreadyMappedMessage, newKey));
                }
                else
                {
                    var newNode = new TreeNode(newKey);
                    selectedNode.Nodes.Add(newNode);
                    var newRegistry = new RegistryEntry { Path = newKey };
                    newNode.Tag = newRegistry;
                    registryGroup.RegistryValues.Add(newRegistry);
                    ConfigurationHelper.Save();
                    Reload();
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
        }

        private void groupRegistryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetRegistryButtonStates(true);
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
            btnApplyChanges.Enabled = IsChangesAvailableToApply(isGroupRegistryTree ? groupRegistryTreeView.Nodes : registryTreeView.Nodes);
            btnClearAll.Enabled = IsChangesAvailableToClear(isGroupRegistryTree ? groupRegistryTreeView.Nodes : registryTreeView.Nodes);
        }

        public void EnableEditButtons(bool value)
        {
            btnDelete.Enabled = btnMapRegistry.Enabled = btnRename.Enabled = value;
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
                    var newNode = new TreeNode(inputForm.InputText);
                    groupRegistryTreeView.Nodes.Add(newNode);
                    var newGroup = new RegistryGroup(inputForm.InputText, false);
                    newNode.Tag = newGroup;
                    ConfigurationHelper.Configuration.Groups.Add(newGroup);
                    ConfigurationHelper.Save();
                }
            }
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

        private bool IsChangesAvailableToClear(TreeNodeCollection tv)
        {
            foreach (TreeNode node in tv)
            {
                if (node.Tag is RegistryEntry && ((RegistryEntry)node.Tag).IsChecked)
                {
                    return true;
                }
                else if (IsChangesAvailableToClear(node.Nodes))
                {
                    return true;
                }
            }
            return false;
        }

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
            RegistryKeysOperation.SetLogParameters(IsChangesAvailableToClear(registryTreeView.Nodes));
            SetRegistryButtonStates(radioBtnGroupRegistry.Checked);
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

        private void radioBtnGroupRegistry_CheckedChanged(object sender, EventArgs e)
        {
            SetTreeViewEnabled((sender as RadioButton).Checked);
        }

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

        private void SetTreeState(CustomTreeView tv, bool enabled)
        {
            tv.Enabled = enabled;
            tv.BackColor = enabled ? Color.White : Color.LightGray;
            tv.LineColor = enabled ? Color.Black : Color.Gray;
            tv.ForeColor = enabled ? Color.Black : Color.Gray;
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
        private void SetLogButtonStates()
        {
            btnOpenFolder.Enabled = Directory.Exists(tbBackupFolder.Text);
            btnCollectLog.Enabled = btnOpenFolder.Enabled && startDateTimePicker.Value < endDateTimePicker.Value;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }

        private void tbBackupFolder_TextChanged(object sender, EventArgs e)
        {
            SetLogButtonStates();
        }
    }
}
