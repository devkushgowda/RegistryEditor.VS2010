
namespace RegistryEditor
{
    partial class RegistryPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registryTree = new RegistryEditor.CustomTreeView();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registryTree
            // 
            this.registryTree.CheckBoxes = true;
            this.registryTree.Location = new System.Drawing.Point(12, 12);
            this.registryTree.Name = "registryTree";
            this.registryTree.Size = new System.Drawing.Size(878, 617);
            this.registryTree.TabIndex = 0;
            this.registryTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.registryTree_AfterCheck);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(737, 649);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(153, 56);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // RegistryPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 729);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.registryTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistryPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RegistryPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private RegistryEditor.CustomTreeView registryTree;
        private System.Windows.Forms.Button okButton;
    }
}