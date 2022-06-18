using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RegistryEditor
{
    public partial class RegistryPicker : Form
    {
        public string SelectedRegistry { private set; get; }
        public RegistryPicker(TreeNodeCollection treeNodeCollection, List<string> exclude)
        {
            InitializeComponent();
            CopyTree(treeNodeCollection, exclude);

            okButton.Enabled = false;
        }

        private void CopyTree(TreeNodeCollection treeNodeCollection, List<string> exclude)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                registryTree.Nodes.Add((TreeNode)node.Clone());
                var xNodes = registryTree.Nodes.AsParallel().Cast<TreeNode>().Where(n => exclude.Contains(n.Text));
                foreach (var xNode in xNodes)
                {
                    registryTree.Nodes.Remove(xNode);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedRegistry = registryTree.SelectedNode.FullPath;
            this.Close();
        }

        private void registryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            okButton.Enabled = true;
        }

        private void registryTree_DoubleClick(object sender, EventArgs e)
        {
            if (registryTree.SelectedNode != null)
            {
                SelectedRegistry = registryTree.SelectedNode.FullPath;
                this.Close();
            }
        }
    }
}
