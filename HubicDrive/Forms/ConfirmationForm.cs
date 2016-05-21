using System;
using System.Windows.Forms;

namespace HubicDrive.Forms {
	public partial class ConfirmationForm : Form {
		private Action<bool> callBack;

		public ConfirmationForm(string text, Action<bool> callBack) {
			this.callBack = callBack;

			InitializeComponent();

			this.lText.Text = text;
			this.Height = this.lText.Height + this.pButtons.Height + 36;
		}


		private void bYes_Click(object sender, EventArgs e) {
			this.callBack(true);
			this.Close();
		}


		private void bNo_Click(object sender, EventArgs e) {
			this.callBack(false);
			this.Close();
		}

	}
}
