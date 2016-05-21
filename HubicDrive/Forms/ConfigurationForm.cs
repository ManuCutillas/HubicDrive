using System;
using System.Windows.Forms;

namespace HubicDrive.Forms {
	public partial class ConfigurationForm : Form {
		public ConfigurationForm() {
			InitializeComponent();

			Configuration config = new Configuration();

			this.emailTextBox.Text = config.Get("email", "");
			this.passwordTextBox.Text = config.Get("password", "", true);
		}


		private void SaveButton_Click(Object sender, EventArgs e) {
			Configuration config = new Configuration();

			config.Set("email", this.emailTextBox.Text);
			config.Set("password", this.passwordTextBox.Text, true);

			this.Close();
		}


		private void CancelButton_Click(Object sender, EventArgs e) {
			this.Close();
		}
	}
}
