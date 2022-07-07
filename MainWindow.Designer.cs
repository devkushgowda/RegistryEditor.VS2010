
namespace RegistryEditor
{
    partial class MainWindow
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
            this.btnMapRegistry = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnNewGroup = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnApplyChanges = new System.Windows.Forms.Button();
            this.radioBtnGroupRegistry = new System.Windows.Forms.RadioButton();
            this.radioBtnManualRegistry = new System.Windows.Forms.RadioButton();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.registryTreeView = new RegistryEditor.CustomTreeView();
            this.groupRegistryTreeView = new RegistryEditor.CustomTreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbBackupFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.mainGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMapRegistry
            // 
            this.btnMapRegistry.Location = new System.Drawing.Point(330, 286);
            this.btnMapRegistry.Margin = new System.Windows.Forms.Padding(1);
            this.btnMapRegistry.Name = "btnMapRegistry";
            this.btnMapRegistry.Size = new System.Drawing.Size(94, 26);
            this.btnMapRegistry.TabIndex = 5;
            this.btnMapRegistry.Text = "Map Registry";
            this.btnMapRegistry.UseVisualStyleBackColor = true;
            this.btnMapRegistry.Click += new System.EventHandler(this.btnMapRegistry_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(330, 223);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Reset";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(330, 349);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 26);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(330, 318);
            this.btnRename.Margin = new System.Windows.Forms.Padding(1);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(94, 26);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Location = new System.Drawing.Point(330, 255);
            this.btnNewGroup.Margin = new System.Windows.Forms.Padding(1);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(94, 26);
            this.btnNewGroup.TabIndex = 9;
            this.btnNewGroup.Text = "New Group";
            this.btnNewGroup.UseVisualStyleBackColor = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(330, 192);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(1);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(94, 26);
            this.btnClearAll.TabIndex = 11;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnApplyChanges
            // 
            this.btnApplyChanges.Location = new System.Drawing.Point(330, 161);
            this.btnApplyChanges.Margin = new System.Windows.Forms.Padding(1);
            this.btnApplyChanges.Name = "btnApplyChanges";
            this.btnApplyChanges.Size = new System.Drawing.Size(94, 26);
            this.btnApplyChanges.TabIndex = 12;
            this.btnApplyChanges.Text = "Apply Changes";
            this.btnApplyChanges.UseVisualStyleBackColor = true;
            this.btnApplyChanges.Click += new System.EventHandler(this.btnApplyChanges_Click);
            // 
            // radioBtnGroupRegistry
            // 
            this.radioBtnGroupRegistry.AutoSize = true;
            this.radioBtnGroupRegistry.Checked = true;
            this.radioBtnGroupRegistry.Location = new System.Drawing.Point(8, 21);
            this.radioBtnGroupRegistry.Margin = new System.Windows.Forms.Padding(1);
            this.radioBtnGroupRegistry.Name = "radioBtnGroupRegistry";
            this.radioBtnGroupRegistry.Size = new System.Drawing.Size(291, 36);
            this.radioBtnGroupRegistry.TabIndex = 13;
            this.radioBtnGroupRegistry.TabStop = true;
            this.radioBtnGroupRegistry.Text = "Group Enablement";
            this.radioBtnGroupRegistry.UseVisualStyleBackColor = true;
            this.radioBtnGroupRegistry.CheckedChanged += new System.EventHandler(this.radioBtnGroupRegistry_CheckedChanged);
            // 
            // radioBtnManualRegistry
            // 
            this.radioBtnManualRegistry.AutoSize = true;
            this.radioBtnManualRegistry.Location = new System.Drawing.Point(434, 21);
            this.radioBtnManualRegistry.Margin = new System.Windows.Forms.Padding(1);
            this.radioBtnManualRegistry.Name = "radioBtnManualRegistry";
            this.radioBtnManualRegistry.Size = new System.Drawing.Size(306, 36);
            this.radioBtnManualRegistry.TabIndex = 14;
            this.radioBtnManualRegistry.Text = "Manual Enablement";
            this.radioBtnManualRegistry.UseVisualStyleBackColor = true;
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.radioBtnManualRegistry);
            this.mainGroupBox.Controls.Add(this.radioBtnGroupRegistry);
            this.mainGroupBox.Controls.Add(this.registryTreeView);
            this.mainGroupBox.Controls.Add(this.btnApplyChanges);
            this.mainGroupBox.Controls.Add(this.groupRegistryTreeView);
            this.mainGroupBox.Controls.Add(this.btnClearAll);
            this.mainGroupBox.Controls.Add(this.btnMapRegistry);
            this.mainGroupBox.Controls.Add(this.btnRefresh);
            this.mainGroupBox.Controls.Add(this.btnNewGroup);
            this.mainGroupBox.Controls.Add(this.btnDelete);
            this.mainGroupBox.Controls.Add(this.btnRename);
            this.mainGroupBox.Location = new System.Drawing.Point(5, -2);
            this.mainGroupBox.Margin = new System.Windows.Forms.Padding(1);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Padding = new System.Windows.Forms.Padding(1);
            this.mainGroupBox.Size = new System.Drawing.Size(760, 483);
            this.mainGroupBox.TabIndex = 15;
            this.mainGroupBox.TabStop = false;
            // 
            // registryTreeView
            // 
            this.registryTreeView.CheckBoxes = true;
            this.registryTreeView.Location = new System.Drawing.Point(434, 40);
            this.registryTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.registryTreeView.Name = "registryTreeView";
            this.registryTreeView.Size = new System.Drawing.Size(320, 435);
            this.registryTreeView.TabIndex = 0;
            this.registryTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.registryTreeView_AfterCheck);
            // 
            // groupRegistryTreeView
            // 
            this.groupRegistryTreeView.CheckBoxes = true;
            this.groupRegistryTreeView.Location = new System.Drawing.Point(8, 40);
            this.groupRegistryTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.groupRegistryTreeView.Name = "groupRegistryTreeView";
            this.groupRegistryTreeView.Size = new System.Drawing.Size(314, 435);
            this.groupRegistryTreeView.TabIndex = 1;
            this.groupRegistryTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.groupRegistryTreeView_BeforeCheck);
            this.groupRegistryTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.groupRegistryTreeView_AfterCheck);
            this.groupRegistryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupRegistryTreeView_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenFolder);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.startDateTimePicker);
            this.groupBox2.Controls.Add(this.tbBackupFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBackupLog);
            this.groupBox2.Controls.Add(this.endDateTimePicker);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblStartDate);
            this.groupBox2.Location = new System.Drawing.Point(5, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 109);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Logs";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(527, 67);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 22);
            this.btnOpenFolder.TabIndex = 20;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(489, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 22);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.CustomFormat = "MMMMdd, yyyy  |  HH:mm";
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new System.Drawing.Point(139, 34);
            this.startDateTimePicker.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(220, 38);
            this.startDateTimePicker.TabIndex = 14;
            this.startDateTimePicker.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // tbBackupFolder
            // 
            this.tbBackupFolder.Location = new System.Drawing.Point(139, 67);
            this.tbBackupFolder.Name = "tbBackupFolder";
            this.tbBackupFolder.Size = new System.Drawing.Size(340, 38);
            this.tbBackupFolder.TabIndex = 1;
            this.tbBackupFolder.TextChanged += new System.EventHandler(this.tbBackupFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Folder:";
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(634, 67);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(74, 22);
            this.btnBackupLog.TabIndex = 18;
            this.btnBackupLog.Text = "Backup";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.CustomFormat = "MMMMdd, yyyy  |  HH:mm";
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTimePicker.Location = new System.Drawing.Point(489, 33);
            this.endDateTimePicker.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(220, 38);
            this.endDateTimePicker.TabIndex = 15;
            this.endDateTimePicker.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "End Date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 39);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(150, 32);
            this.lblStartDate.TabIndex = 16;
            this.lblStartDate.Text = "Start Date:";
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(770, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.mainGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP1 Log Collector";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RegistryEditor.CustomTreeView registryTreeView;
        private RegistryEditor.CustomTreeView groupRegistryTreeView;
        private System.Windows.Forms.Button btnMapRegistry;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnNewGroup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnApplyChanges;
        private System.Windows.Forms.RadioButton radioBtnGroupRegistry;
        private System.Windows.Forms.RadioButton radioBtnManualRegistry;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.TextBox tbBackupFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}

