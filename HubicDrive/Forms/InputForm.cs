using System;
using System.Windows.Forms;

namespace HubicDrive {
	public partial class InputForm : Form {
		private Action<string> callBack;


		public InputForm(string text, Action<string> callBack) {
			this.callBack = callBack;

			InitializeComponent();

			this.lText.Text = text;
			this.Height = this.lText.Height + this.splitContainer1.Height + 36;

		}


		private void bAccept_Click(object sender, EventArgs e) {
			this.callBack(this.textBox1.Text);
			this.Close();
		}


		private void bCancel_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
