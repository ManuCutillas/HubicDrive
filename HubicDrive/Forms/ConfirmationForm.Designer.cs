namespace HubicDrive.Forms {
	partial class ConfirmationForm {
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
			this.lText = new System.Windows.Forms.Label();
			this.bNo = new System.Windows.Forms.Button();
			this.bYes = new System.Windows.Forms.Button();
			this.pButtons = new System.Windows.Forms.Panel();
			this.pButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// lText
			// 
			this.lText.AutoSize = true;
			this.lText.Dock = System.Windows.Forms.DockStyle.Top;
			this.lText.Location = new System.Drawing.Point(0, 0);
			this.lText.Name = "lText";
			this.lText.Padding = new System.Windows.Forms.Padding(12);
			this.lText.Size = new System.Drawing.Size(73, 37);
			this.lText.TabIndex = 0;
			this.lText.Text = "Question";
			// 
			// bNo
			// 
			this.bNo.Location = new System.Drawing.Point(197, 8);
			this.bNo.Name = "bNo";
			this.bNo.Size = new System.Drawing.Size(75, 23);
			this.bNo.TabIndex = 1;
			this.bNo.Text = "No";
			this.bNo.UseVisualStyleBackColor = true;
			this.bNo.Click += new System.EventHandler(this.bNo_Click);
			// 
			// bYes
			// 
			this.bYes.Location = new System.Drawing.Point(14, 8);
			this.bYes.Name = "bYes";
			this.bYes.Size = new System.Drawing.Size(75, 23);
			this.bYes.TabIndex = 0;
			this.bYes.Text = "Yes";
			this.bYes.UseVisualStyleBackColor = true;
			this.bYes.Click += new System.EventHandler(this.bYes_Click);
			// 
			// pButtons
			// 
			this.pButtons.Controls.Add(this.bNo);
			this.pButtons.Controls.Add(this.bYes);
			this.pButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pButtons.Location = new System.Drawing.Point(0, 57);
			this.pButtons.Name = "pButtons";
			this.pButtons.Size = new System.Drawing.Size(284, 41);
			this.pButtons.TabIndex = 1;
			// 
			// ConfirmationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 98);
			this.Controls.Add(this.lText);
			this.Controls.Add(this.pButtons);
			this.Name = "ConfirmationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ConfirmationForm";
			this.pButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lText;
		private System.Windows.Forms.Button bNo;
		private System.Windows.Forms.Button bYes;
		private System.Windows.Forms.Panel pButtons;
	}
}