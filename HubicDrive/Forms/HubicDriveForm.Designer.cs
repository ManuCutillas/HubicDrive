namespace HubicDrive.Forms
{
    partial class HubicDriveForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HubicDriveForm));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.stripMenuItemHubic = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.containerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.connectToolButton = new System.Windows.Forms.ToolStripButton();
			this.disconnectToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.createContainerToolButton = new System.Windows.Forms.ToolStripButton();
			this.deleteContainerToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.createFolderToolButton = new System.Windows.Forms.ToolStripButton();
			this.deleteFolderToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.uploadToolButton = new System.Windows.Forms.ToolStripButton();
			this.downloadToolButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.queueToolButton = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.foldersTreeView = new HubicDrive.Controls.FoldersTreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.containersComboBox = new HubicDrive.Controls.ContainersComboBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.folderInfoLabel = new System.Windows.Forms.Label();
			this.filesListView = new HubicDrive.Controls.FilesListView();
			this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.connectionStatus = new HubicDrive.Controls.ConnectionStatus();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder-blue.png");
			this.imageList1.Images.SetKeyName(1, "file.png");
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuItemHubic,
            this.containerToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1057, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// stripMenuItemHubic
			// 
			this.stripMenuItemHubic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnect,
            this.menuItemDisconnect,
            this.toolStripMenuItem1});
			this.stripMenuItemHubic.Name = "stripMenuItemHubic";
			this.stripMenuItemHubic.Size = new System.Drawing.Size(51, 20);
			this.stripMenuItemHubic.Text = "Hubic";
			// 
			// menuItemConnect
			// 
			this.menuItemConnect.Name = "menuItemConnect";
			this.menuItemConnect.Size = new System.Drawing.Size(148, 22);
			this.menuItemConnect.Text = "Connect";
			// 
			// menuItemDisconnect
			// 
			this.menuItemDisconnect.Name = "menuItemDisconnect";
			this.menuItemDisconnect.Size = new System.Drawing.Size(148, 22);
			this.menuItemDisconnect.Text = "Disconnect";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem1.Text = "Configuration";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ConfigurationMenuItem_Click);
			// 
			// containerToolStripMenuItem
			// 
			this.containerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.uploadToolStripMenuItem});
			this.containerToolStripMenuItem.Name = "containerToolStripMenuItem";
			this.containerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.containerToolStripMenuItem.Text = "Container";
			// 
			// createToolStripMenuItem
			// 
			this.createToolStripMenuItem.Name = "createToolStripMenuItem";
			this.createToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.createToolStripMenuItem.Text = "Create";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// uploadToolStripMenuItem
			// 
			this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
			this.uploadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.uploadToolStripMenuItem.Text = "Upload";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolButton,
            this.disconnectToolButton,
            this.toolStripSeparator1,
            this.createContainerToolButton,
            this.deleteContainerToolButton,
            this.toolStripSeparator2,
            this.createFolderToolButton,
            this.deleteFolderToolButton,
            this.toolStripSeparator3,
            this.uploadToolButton,
            this.downloadToolButton,
            this.deleteToolButton,
            this.toolStripSeparator4,
            this.queueToolButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1057, 38);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// connectToolButton
			// 
			this.connectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("connectToolButton.Image")));
			this.connectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectToolButton.Name = "connectToolButton";
			this.connectToolButton.Size = new System.Drawing.Size(56, 35);
			this.connectToolButton.Text = "Connect";
			this.connectToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.connectToolButton.Click += new System.EventHandler(this.ConnectToolStripButton_Click);
			// 
			// disconnectToolButton
			// 
			this.disconnectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolButton.Image")));
			this.disconnectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectToolButton.Name = "disconnectToolButton";
			this.disconnectToolButton.Size = new System.Drawing.Size(70, 35);
			this.disconnectToolButton.Text = "Disconnect";
			this.disconnectToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.disconnectToolButton.Visible = false;
			this.disconnectToolButton.Click += new System.EventHandler(this.DisconnectToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// createContainerToolButton
			// 
			this.createContainerToolButton.Enabled = false;
			this.createContainerToolButton.Image = ((System.Drawing.Image)(resources.GetObject("createContainerToolButton.Image")));
			this.createContainerToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createContainerToolButton.Name = "createContainerToolButton";
			this.createContainerToolButton.Size = new System.Drawing.Size(98, 35);
			this.createContainerToolButton.Text = "Create container";
			this.createContainerToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.createContainerToolButton.Click += new System.EventHandler(this.CreateContainerToolStripButton_Click);
			// 
			// deleteContainerToolButton
			// 
			this.deleteContainerToolButton.Enabled = false;
			this.deleteContainerToolButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteContainerToolButton.Image")));
			this.deleteContainerToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteContainerToolButton.Name = "deleteContainerToolButton";
			this.deleteContainerToolButton.Size = new System.Drawing.Size(97, 35);
			this.deleteContainerToolButton.Text = "Delete container";
			this.deleteContainerToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.deleteContainerToolButton.Click += new System.EventHandler(this.DeleteContainerToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// createFolderToolButton
			// 
			this.createFolderToolButton.Enabled = false;
			this.createFolderToolButton.Image = ((System.Drawing.Image)(resources.GetObject("createFolderToolButton.Image")));
			this.createFolderToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createFolderToolButton.Name = "createFolderToolButton";
			this.createFolderToolButton.Size = new System.Drawing.Size(79, 35);
			this.createFolderToolButton.Text = "Create folder";
			this.createFolderToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.createFolderToolButton.Click += new System.EventHandler(this.CreateFolderToolStripButton_Click);
			// 
			// deleteFolderToolButton
			// 
			this.deleteFolderToolButton.Enabled = false;
			this.deleteFolderToolButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteFolderToolButton.Image")));
			this.deleteFolderToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteFolderToolButton.Name = "deleteFolderToolButton";
			this.deleteFolderToolButton.Size = new System.Drawing.Size(78, 35);
			this.deleteFolderToolButton.Text = "Delete folder";
			this.deleteFolderToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.deleteFolderToolButton.Click += new System.EventHandler(this.DeleteFolderToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// uploadToolButton
			// 
			this.uploadToolButton.Enabled = false;
			this.uploadToolButton.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolButton.Image")));
			this.uploadToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uploadToolButton.Name = "uploadToolButton";
			this.uploadToolButton.Size = new System.Drawing.Size(49, 35);
			this.uploadToolButton.Text = "Upload";
			this.uploadToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.uploadToolButton.Click += new System.EventHandler(this.UploadToolStripButton_Click);
			// 
			// downloadToolButton
			// 
			this.downloadToolButton.Enabled = false;
			this.downloadToolButton.Image = ((System.Drawing.Image)(resources.GetObject("downloadToolButton.Image")));
			this.downloadToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.downloadToolButton.Name = "downloadToolButton";
			this.downloadToolButton.Size = new System.Drawing.Size(65, 35);
			this.downloadToolButton.Text = "Download";
			this.downloadToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.downloadToolButton.Click += new System.EventHandler(this.DownloadFilesToolStripButton_Click);
			// 
			// deleteToolButton
			// 
			this.deleteToolButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolButton.Image")));
			this.deleteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolButton.Name = "deleteToolButton";
			this.deleteToolButton.Size = new System.Drawing.Size(44, 35);
			this.deleteToolButton.Text = "Delete";
			this.deleteToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.deleteToolButton.Click += new System.EventHandler(this.DeleteFilesToolStripButton_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// queueToolButton
			// 
			this.queueToolButton.Enabled = false;
			this.queueToolButton.Image = ((System.Drawing.Image)(resources.GetObject("queueToolButton.Image")));
			this.queueToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.queueToolButton.Name = "queueToolButton";
			this.queueToolButton.Size = new System.Drawing.Size(46, 35);
			this.queueToolButton.Text = "Queue";
			this.queueToolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.queueToolButton.ToolTipText = "Open queue dialog";
			this.queueToolButton.Click += new System.EventHandler(this.QueueToolStripButton_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 62);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.foldersTreeView);
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			this.splitContainer1.Panel1.Controls.Add(this.panel3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.filesListView);
			this.splitContainer1.Panel2.Controls.Add(this.connectionStatus);
			this.splitContainer1.Size = new System.Drawing.Size(1057, 507);
			this.splitContainer1.SplitterDistance = 352;
			this.splitContainer1.TabIndex = 14;
			// 
			// foldersTreeView
			// 
			this.foldersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.foldersTreeView.Enabled = false;
			this.foldersTreeView.HideSelection = false;
			this.foldersTreeView.ImageIndex = 0;
			this.foldersTreeView.ImageList = this.imageList1;
			this.foldersTreeView.Location = new System.Drawing.Point(0, 30);
			this.foldersTreeView.Name = "foldersTreeView";
			this.foldersTreeView.SelectedImageIndex = 0;
			this.foldersTreeView.Size = new System.Drawing.Size(352, 455);
			this.foldersTreeView.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.containersComboBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(352, 30);
			this.panel1.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Containers";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// containersComboBox
			// 
			this.containersComboBox.Enabled = false;
			this.containersComboBox.FormattingEnabled = true;
			this.containersComboBox.Location = new System.Drawing.Point(65, 5);
			this.containersComboBox.Name = "containersComboBox";
			this.containersComboBox.Size = new System.Drawing.Size(284, 21);
			this.containersComboBox.Sorted = true;
			this.containersComboBox.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.folderInfoLabel);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 485);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(352, 22);
			this.panel3.TabIndex = 4;
			// 
			// folderInfoLabel
			// 
			this.folderInfoLabel.AutoSize = true;
			this.folderInfoLabel.Location = new System.Drawing.Point(5, 5);
			this.folderInfoLabel.Name = "folderInfoLabel";
			this.folderInfoLabel.Size = new System.Drawing.Size(77, 13);
			this.folderInfoLabel.TabIndex = 0;
			this.folderInfoLabel.Text = "folderInfoLabel";
			this.folderInfoLabel.Visible = false;
			// 
			// filesListView
			// 
			this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize,
            this.FileDate});
			this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filesListView.Enabled = false;
			this.filesListView.FullRowSelect = true;
			this.filesListView.HideSelection = false;
			this.filesListView.LargeImageList = this.imageList1;
			this.filesListView.Location = new System.Drawing.Point(0, 0);
			this.filesListView.Name = "filesListView";
			this.filesListView.Size = new System.Drawing.Size(701, 485);
			this.filesListView.SmallImageList = this.imageList1;
			this.filesListView.TabIndex = 0;
			this.filesListView.UseCompatibleStateImageBehavior = false;
			this.filesListView.View = System.Windows.Forms.View.Details;
			// 
			// FileName
			// 
			this.FileName.Text = "Name";
			this.FileName.Width = 300;
			// 
			// FileSize
			// 
			this.FileSize.Text = "Size";
			this.FileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.FileSize.Width = 80;
			// 
			// FileDate
			// 
			this.FileDate.Text = "Date";
			this.FileDate.Width = 120;
			// 
			// connectionStatus
			// 
			this.connectionStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.connectionStatus.Location = new System.Drawing.Point(0, 485);
			this.connectionStatus.Name = "connectionStatus";
			this.connectionStatus.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
			this.connectionStatus.Size = new System.Drawing.Size(701, 22);
			this.connectionStatus.TabIndex = 2;
			// 
			// HubicDriveForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1057, 569);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HubicDriveForm";
			this.Text = "Hubic Drive";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem stripMenuItemHubic;
		private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
		private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem containerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton connectToolButton;
		private System.Windows.Forms.ToolStripButton disconnectToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton createContainerToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private Controls.ContainersComboBox containersComboBox;
		private Controls.ConnectionStatus connectionStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.ToolStripButton deleteContainerToolButton;
		private HubicDrive.Controls.FilesListView filesListView;
		private HubicDrive.Controls.FoldersTreeView foldersTreeView;
		private System.Windows.Forms.ColumnHeader FileName;
		private System.Windows.Forms.ColumnHeader FileSize;
		private System.Windows.Forms.ColumnHeader FileDate;
		private System.Windows.Forms.Label folderInfoLabel;
		public System.Windows.Forms.ToolStripButton createFolderToolButton;
		public System.Windows.Forms.ToolStripButton deleteFolderToolButton;
		public System.Windows.Forms.ToolStripButton downloadToolButton;
		public System.Windows.Forms.ToolStripButton uploadToolButton;
		private System.Windows.Forms.ToolStripButton queueToolButton;
		private System.Windows.Forms.ToolStripButton deleteToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}

