namespace HubicDrive.Controls {
	partial class ConnectionStatus {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lMessage = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// lMessage
			// 
			this.lMessage.AutoSize = true;
			this.lMessage.Dock = System.Windows.Forms.DockStyle.Right;
			this.lMessage.Location = new System.Drawing.Point(83, 0);
			this.lMessage.Name = "lMessage";
			this.lMessage.Padding = new System.Windows.Forms.Padding(0, 4, 10, 0);
			this.lMessage.Size = new System.Drawing.Size(60, 17);
			this.lMessage.TabIndex = 0;
			this.lMessage.Text = "Message";
			this.lMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// progressBar
			// 
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Right;
			this.progressBar.Location = new System.Drawing.Point(143, 0);
			this.progressBar.MarqueeAnimationSpeed = 24;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(100, 20);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 1;
			// 
			// ConnectionStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lMessage);
			this.Controls.Add(this.progressBar);
			this.Name = "ConnectionStatus";
			this.Size = new System.Drawing.Size(243, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lMessage;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}
