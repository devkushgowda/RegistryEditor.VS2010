﻿
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnNewGroup = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnApplyChanges = new System.Windows.Forms.Button();
            this.radioBtnGroupRegistry = new System.Windows.Forms.RadioButton();
            this.radioBtnManualRegistry = new System.Windows.Forms.RadioButton();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.registryTreeView = new RegistryEditor.CustomTreeView();
            this.groupRegistryTreeView = new RegistryEditor.CustomTreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.tbBackupFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.mainGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMapRegistry
            // 
            this.btnMapRegistry.Location = new System.Drawing.Point(331, 210);
            this.btnMapRegistry.Margin = new System.Windows.Forms.Padding(1);
            this.btnMapRegistry.Name = "btnMapRegistry";
            this.btnMapRegistry.Size = new System.Drawing.Size(94, 26);
            this.btnMapRegistry.TabIndex = 5;
            this.btnMapRegistry.Text = "Map Registry";
            this.btnMapRegistry.UseVisualStyleBackColor = true;
            this.btnMapRegistry.Click += new System.EventHandler(this.btnMapRegistry_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(331, 150);
            this.btnReset.Margin = new System.Windows.Forms.Padding(1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 26);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(331, 270);
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
            this.btnRename.Location = new System.Drawing.Point(331, 240);
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
            this.btnNewGroup.Location = new System.Drawing.Point(331, 180);
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
            this.btnClearAll.Location = new System.Drawing.Point(331, 120);
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
            this.btnApplyChanges.Location = new System.Drawing.Point(331, 90);
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
            this.mainGroupBox.Controls.Add(this.btnExit);
            this.mainGroupBox.Controls.Add(this.radioBtnManualRegistry);
            this.mainGroupBox.Controls.Add(this.radioBtnGroupRegistry);
            this.mainGroupBox.Controls.Add(this.registryTreeView);
            this.mainGroupBox.Controls.Add(this.btnApplyChanges);
            this.mainGroupBox.Controls.Add(this.groupRegistryTreeView);
            this.mainGroupBox.Controls.Add(this.btnClearAll);
            this.mainGroupBox.Controls.Add(this.btnMapRegistry);
            this.mainGroupBox.Controls.Add(this.btnReset);
            this.mainGroupBox.Controls.Add(this.btnNewGroup);
            this.mainGroupBox.Controls.Add(this.btnDelete);
            this.mainGroupBox.Controls.Add(this.btnRename);
            this.mainGroupBox.Location = new System.Drawing.Point(5, -2);
            this.mainGroupBox.Margin = new System.Windows.Forms.Padding(1);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Padding = new System.Windows.Forms.Padding(1);
            this.mainGroupBox.Size = new System.Drawing.Size(760, 382);
            this.mainGroupBox.TabIndex = 15;
            this.mainGroupBox.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(331, 300);
            this.btnExit.Margin = new System.Windows.Forms.Padding(1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 26);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // registryTreeView
            // 
            this.registryTreeView.CheckBoxes = true;
            this.registryTreeView.Location = new System.Drawing.Point(434, 40);
            this.registryTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.registryTreeView.Name = "registryTreeView";
            this.registryTreeView.Size = new System.Drawing.Size(320, 335);
            this.registryTreeView.TabIndex = 0;
            this.registryTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.registryTreeView_AfterCheck);
            // 
            // groupRegistryTreeView
            // 
            this.groupRegistryTreeView.CheckBoxes = true;
            this.groupRegistryTreeView.Location = new System.Drawing.Point(8, 40);
            this.groupRegistryTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.groupRegistryTreeView.Name = "groupRegistryTreeView";
            this.groupRegistryTreeView.Size = new System.Drawing.Size(314, 335);
            this.groupRegistryTreeView.TabIndex = 1;
            this.groupRegistryTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.groupRegistryTreeView_BeforeCheck);
            this.groupRegistryTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.groupRegistryTreeView_AfterCheck);
            this.groupRegistryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupRegistryTreeView_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.endTime);
            this.groupBox2.Controls.Add(this.endDate);
            this.groupBox2.Controls.Add(this.startTime);
            this.groupBox2.Controls.Add(this.btnOpenFolder);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.startDate);
            this.groupBox2.Controls.Add(this.tbBackupFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBackupLog);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblStartDate);
            this.groupBox2.Location = new System.Drawing.Point(5, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 116);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Logs";
            // 
            // endTime
            // 
            this.endTime.CustomFormat = "HH : mm : ss";
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTime.Location = new System.Drawing.Point(637, 34);
            this.endTime.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.endTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.endTime.Name = "endTime";
            this.endTime.ShowUpDown = true;
            this.endTime.Size = new System.Drawing.Size(77, 38);
            this.endTime.TabIndex = 23;
            this.endTime.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.endTime.ValueChanged += new System.EventHandler(this.endTime_ValueChanged);
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "MMMMdd, yyyy";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(489, 34);
            this.endDate.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.endDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(142, 38);
            this.endDate.TabIndex = 22;
            this.endDate.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "HH : mm : ss";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(287, 34);
            this.startTime.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.startTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(77, 38);
            this.startTime.TabIndex = 21;
            this.startTime.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.startTime.ValueChanged += new System.EventHandler(this.startTime_ValueChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Location = new System.Drawing.Point(637, 73);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(77, 22);
            this.btnOpenFolder.TabIndex = 20;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(489, 73);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 20);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "MMMMdd, yyyy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(139, 34);
            this.startDate.MaxDate = new System.DateTime(2300, 1, 1, 0, 0, 0, 0);
            this.startDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(142, 38);
            this.startDate.TabIndex = 14;
            this.startDate.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // tbBackupFolder
            // 
            this.tbBackupFolder.Location = new System.Drawing.Point(139, 73);
            this.tbBackupFolder.Name = "tbBackupFolder";
            this.tbBackupFolder.Size = new System.Drawing.Size(340, 38);
            this.tbBackupFolder.TabIndex = 1;
            this.tbBackupFolder.TextChanged += new System.EventHandler(this.tbBackupFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Folder:";
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(527, 70);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(104, 25);
            this.btnBackupLog.TabIndex = 18;
            this.btnBackupLog.Text = "Backup";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click);
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
            this.ClientSize = new System.Drawing.Size(770, 504);
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
        private System.Windows.Forms.Button btnReset;
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
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox tbBackupFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Button btnExit;
    }
}

