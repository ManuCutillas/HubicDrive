namespace HubicDrive.Forms {
	partial class QueueForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.removeStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
			this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.queueStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.queueStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.maxSimultaneousTransfersNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.queueListView = new HubicDrive.Controls.QueueListView();
			this.containerHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.remotePathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.localPathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.porgressHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.speedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.etaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.directionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxSimultaneousTransfersNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.AllowMerge = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.removeStripSplitButton,
            this.toolStripSeparator1,
            this.toolStripLabel1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(957, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(35, 22);
			this.toolStripButton1.Text = "Start";
			this.toolStripButton1.Click += new System.EventHandler(this.Start);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(35, 22);
			this.toolStripButton2.Text = "Stop";
			this.toolStripButton2.Click += new System.EventHandler(this.Stop);
			// 
			// removeStripSplitButton
			// 
			this.removeStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.removeStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.removeFinishedToolStripMenuItem});
			this.removeStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("removeStripSplitButton.Image")));
			this.removeStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.removeStripSplitButton.Name = "removeStripSplitButton";
			this.removeStripSplitButton.Size = new System.Drawing.Size(66, 22);
			this.removeStripSplitButton.Text = "Remove";
			// 
			// removeSelectedToolStripMenuItem
			// 
			this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
			this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.removeSelectedToolStripMenuItem.Text = "Selected";
			this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelected);
			// 
			// removeFinishedToolStripMenuItem
			// 
			this.removeFinishedToolStripMenuItem.Name = "removeFinishedToolStripMenuItem";
			this.removeFinishedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.removeFinishedToolStripMenuItem.Text = "Finished";
			this.removeFinishedToolStripMenuItem.Click += new System.EventHandler(this.RemoveFinished);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(171, 22);
			this.toolStripLabel1.Text = "Max simultaneous connections";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queueStripStatusLabel,
            this.queueStripProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 498);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(957, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// queueStripStatusLabel
			// 
			this.queueStripStatusLabel.Name = "queueStripStatusLabel";
			this.queueStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.queueStripStatusLabel.Text = "Status";
			// 
			// queueStripProgressBar
			// 
			this.queueStripProgressBar.Name = "queueStripProgressBar";
			this.queueStripProgressBar.Size = new System.Drawing.Size(100, 16);
			this.queueStripProgressBar.Step = 1;
			this.queueStripProgressBar.Visible = false;
			// 
			// maxSimultaneousTransfersNumericUpDown
			// 
			this.maxSimultaneousTransfersNumericUpDown.Location = new System.Drawing.Point(327, 3);
			this.maxSimultaneousTransfersNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.maxSimultaneousTransfersNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.maxSimultaneousTransfersNumericUpDown.Name = "maxSimultaneousTransfersNumericUpDown";
			this.maxSimultaneousTransfersNumericUpDown.Size = new System.Drawing.Size(43, 20);
			this.maxSimultaneousTransfersNumericUpDown.TabIndex = 3;
			this.maxSimultaneousTransfersNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.maxSimultaneousTransfersNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.maxSimultaneousTransfersNumericUpDown.ValueChanged += new System.EventHandler(this.MaxSimultaneousTransfers_ValueChanged);
			// 
			// queueListView
			// 
			this.queueListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.containerHeader,
            this.remotePathHeader,
            this.localPathHeader,
            this.sizeHeader,
            this.porgressHeader,
            this.speedHeader,
            this.etaHeader,
            this.directionHeader});
			this.queueListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.queueListView.FullRowSelect = true;
			this.queueListView.HideSelection = false;
			this.queueListView.Location = new System.Drawing.Point(0, 25);
			this.queueListView.Name = "queueListView";
			this.queueListView.Size = new System.Drawing.Size(957, 473);
			this.queueListView.TabIndex = 2;
			this.queueListView.UseCompatibleStateImageBehavior = false;
			this.queueListView.View = System.Windows.Forms.View.Details;
			// 
			// containerHeader
			// 
			this.containerHeader.Text = "Container";
			// 
			// remotePathHeader
			// 
			this.remotePathHeader.Text = "Remote Path";
			this.remotePathHeader.Width = 241;
			// 
			// localPathHeader
			// 
			this.localPathHeader.Text = "Local Path";
			this.localPathHeader.Width = 291;
			// 
			// sizeHeader
			// 
			this.sizeHeader.Text = "Size";
			this.sizeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// porgressHeader
			// 
			this.porgressHeader.Text = "Progress";
			this.porgressHeader.Width = 75;
			// 
			// speedHeader
			// 
			this.speedHeader.Text = "Speed";
			this.speedHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// etaHeader
			// 
			this.etaHeader.Text = "ETA";
			this.etaHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// directionHeader
			// 
			this.directionHeader.Text = "Direction";
			// 
			// QueueForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(957, 520);
			this.Controls.Add(this.maxSimultaneousTransfersNumericUpDown);
			this.Controls.Add(this.queueListView);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "QueueForm";
			this.Text = "Queue";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueueForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxSimultaneousTransfersNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel queueStripStatusLabel;
		private System.Windows.Forms.ToolStripProgressBar queueStripProgressBar;
		private Controls.QueueListView queueListView;
		private System.Windows.Forms.ColumnHeader remotePathHeader;
		private System.Windows.Forms.ColumnHeader localPathHeader;
		private System.Windows.Forms.ColumnHeader porgressHeader;
		private System.Windows.Forms.ColumnHeader directionHeader;
		private System.Windows.Forms.ColumnHeader containerHeader;
		private System.Windows.Forms.ColumnHeader sizeHeader;
		private System.Windows.Forms.ColumnHeader speedHeader;
		private System.Windows.Forms.ToolStripSplitButton removeStripSplitButton;
		private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeFinishedToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.NumericUpDown maxSimultaneousTransfersNumericUpDown;
		private System.Windows.Forms.ColumnHeader etaHeader;
	}
}