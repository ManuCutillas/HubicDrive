namespace HubicDrive {
	partial class InputForm {
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
			this.bAccept = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lText
			// 
			this.lText.AutoSize = true;
			this.lText.Dock = System.Windows.Forms.DockStyle.Top;
			this.lText.Location = new System.Drawing.Point(0, 0);
			this.lText.Margin = new System.Windows.Forms.Padding(0);
			this.lText.Name = "lText";
			this.lText.Padding = new System.Windows.Forms.Padding(12);
			this.lText.Size = new System.Drawing.Size(73, 37);
			this.lText.TabIndex = 0;
			this.lText.Text = "Question";
			// 
			// bAccept
			// 
			this.bAccept.Location = new System.Drawing.Point(12, 11);
			this.bAccept.Name = "bAccept";
			this.bAccept.Size = new System.Drawing.Size(75, 23);
			this.bAccept.TabIndex = 1;
			this.bAccept.Text = "Accept";
			this.bAccept.UseVisualStyleBackColor = true;
			this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(257, 11);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 2;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 20);
			this.textBox1.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitContainer1.Location = new System.Drawing.Point(0, 68);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(12);
			this.splitContainer1.Panel1MinSize = 20;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.bAccept);
			this.splitContainer1.Panel2.Controls.Add(this.bCancel);
			this.splitContainer1.Size = new System.Drawing.Size(344, 86);
			this.splitContainer1.SplitterDistance = 41;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 4;
			// 
			// InputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 154);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.lText);
			this.Name = "InputForm";
			this.Text = "InputForm";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lText;
		private System.Windows.Forms.Button bAccept;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}