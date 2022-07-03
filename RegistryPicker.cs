using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RegistryEditor.Models;

namespace RegistryEditor
{
    public partial class RegistryPicker : Form
    {
        public List<string> SelectedRegistryList { private set; get; }
        public RegistryPicker(TreeNodeCollection treeNodeCollection, List<string> exclude)
        {
            InitializeComponent();
            CopyTree(treeNodeCollection, exclude);
            okButton.Enabled = false;
            SelectedRegistryList = new List<string>();
        }

        private void CopyTree(TreeNodeCollection treeNodeCollection, List<string> exclude)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                var clone = (TreeNode)node.Clone();
                clone.Checked = false;
                registryTree.Nodes.Add(clone);
                var xNodes = registryTree.Nodes.AsParallel().Cast<TreeNode>().Where(n => exclude.Contains(n.Text));
                foreach (var xNode in xNodes)
                {
                    registryTree.Nodes.Remove(xNode);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedRegistryList = registryTree.Nodes.AsParallel().Cast<TreeNode>().Where(t => t.Checked)
                .Select(t => ((RegistryEntry)t.Tag).Name).ToList();
            this.Close();
        }

        private void registryTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            okButton.Enabled = registryTree.Nodes.AsParallel().Cast<TreeNode>().Any(t => t.Checked);
        }
    }
}
