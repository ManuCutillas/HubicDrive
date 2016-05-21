using HubicDrive.Controls;
using HubicDrive.OpenStack;
using System;
using System.Windows.Forms;
using HubicDrive.Hubic;

namespace HubicDrive.Forms {
	public partial class HubicDriveForm : Form {
		public HubicAPI HAPI;
		private OpenStackAPI OSAPI;
		private Configuration Config = new Configuration();
		public QueueForm queueForm = null;


		public HubicDriveForm() {
			InitializeComponent();
			connectionStatus.SetStatus("Status: disconnected");
		}


		private void ConnectToolStripButton_Click(object sender, EventArgs e) {
			connectionStatus.SetStatus("Status: connecting...", 0, 100);

			this.HAPI = new HubicAPI(Config.Get("email"), Config.Get("password", null, true));

			this.OSAPI = new OpenStackAPI(this.HAPI);
			this.queueForm = new QueueForm(this.HAPI, this.OSAPI);

			connectionStatus.SetStatus("Status: connected");

			connectToolButton.Enabled = false;
			connectToolButton.Visible = false;
			disconnectToolButton.Enabled = true;
			disconnectToolButton.Visible = true;
			createContainerToolButton.Enabled = true;
			queueToolButton.Enabled = true;

			containersComboBox.Load(this.OSAPI, true);
		}
		

		private void DisconnectToolStripButton_Click(object sender, EventArgs e) {
			connectionStatus.SetStatus("Status: disconnected");

			disconnectToolButton.Enabled = false;
			disconnectToolButton.Visible = false;
			connectToolButton.Visible = true;
			connectToolButton.Enabled = true;
			createContainerToolButton.Enabled = false;
			deleteContainerToolButton.Enabled = false;
			createFolderToolButton.Enabled = false;
			deleteFolderToolButton.Enabled = false;
			queueToolButton.Enabled = false;

			containersComboBox.Enabled = false;
			containersComboBox.Text = "";
			containersComboBox.Items.Clear();

			foldersTreeView.Enabled = false;
			foldersTreeView.Nodes.Clear();

			filesListView.Enabled = false;
			filesListView.Items.Clear();

			folderInfoLabel.Visible = false;
		}


		private void CreateContainerToolStripButton_Click(object sender, EventArgs e) {
			InputForm iForm = new InputForm("Enter the new container name", containersComboBox.Create);
			iForm.Show();
		}


		private void DeleteContainerToolStripButton_Click(object sender, EventArgs e) {
			OSContainer container = containersComboBox.GetSelectedContainer();

			ConfirmationForm cForm = new ConfirmationForm("Do you really want to delete the container " + container.Name, containersComboBox.Delete);
			cForm.Show();
		}


		private void CreateFolderToolStripButton_Click(object sender, EventArgs e) {
			InputForm iForm = new InputForm("Enter the new folder name", foldersTreeView.Create);
			iForm.Show();
		}


		private void DeleteFolderToolStripButton_Click(object sender, EventArgs e) {
			OSFolder folder = foldersTreeView.GetSelectedFolder();

			ConfirmationForm cForm = new ConfirmationForm("Do you really want to delete the folder " + folder.Name, foldersTreeView.Delete);
			cForm.Show();
		}


		private void UploadToolStripButton_Click(object sender, EventArgs e) {
			foldersTreeView.Upload();
		}


		private void DownloadFilesToolStripButton_Click(object sender, EventArgs e) {
			filesListView.DownloadSelected();
		}


		private void DeleteFilesToolStripButton_Click(object sender, EventArgs e) {
			filesListView.DeleteSelected();
		}


		private void QueueToolStripButton_Click(object sender, EventArgs e) {
			this.queueForm.Show();
		}


		public ConnectionStatus GetConnectionStatus() {
			return connectionStatus;
		}


		public FoldersTreeView GetFoldersTreeView() {
			return foldersTreeView;
		}


		public Label GetFolderInfoLabel() {
			return folderInfoLabel;
		}


		public FilesListView GetFilesListView() {
			return filesListView;
		}


		private void ConfigurationMenuItem_Click(object sender, EventArgs e) {
			ConfigurationForm form = new ConfigurationForm();
			form.Show();
		}
	}
}
