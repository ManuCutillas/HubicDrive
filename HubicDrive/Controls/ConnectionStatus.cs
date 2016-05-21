using System.Windows.Forms;
using HubicDrive.Forms;

namespace HubicDrive.Controls {
	public partial class ConnectionStatus : UserControl {
		public ConnectionStatus() {
			InitializeComponent();
		}


		public HubicDriveForm GetForm() {
			return (HubicDriveForm) this.FindForm();
		}


		public void SetStatus(string text, bool marquee = false) {
			lMessage.Text = text;

			if (marquee) {
				progressBar.Value = 0;
				progressBar.Maximum = 100;
				progressBar.Style = ProgressBarStyle.Marquee;
				progressBar.Visible = true;

				this.GetForm().Cursor = Cursors.WaitCursor;

			} else {
				progressBar.Visible = false;

				this.GetForm().Cursor = Cursors.Default;
			}

			this.Update();
		}


		public void SetStatus(string text, int current, int maximum = 0) {
			lMessage.Text = text;
			progressBar.Value = current;

			if (maximum > 0) {
				progressBar.Value = 0;
				progressBar.Style = ProgressBarStyle.Blocks;
				progressBar.Maximum = maximum;

				this.GetForm().Cursor = Cursors.WaitCursor;

			} else if (current == progressBar.Maximum) {
				progressBar.Visible = false;

				this.GetForm().Cursor = Cursors.Default;
			}

			this.Update();
		}
	}
}
