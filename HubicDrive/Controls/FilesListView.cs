using HubicDrive.OpenStack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HubicDrive.Forms;

namespace HubicDrive.Controls {
	public class FilesListView: ListView {
		private OpenStackAPI OSAPI;
		private OSContainer OSContainer;
		private OSFolder OSFolder;


		public HubicDriveForm GetForm() {
			return (HubicDriveForm) this.FindForm();
		}


		public void Load(OpenStackAPI OSAPI, OSContainer container, OSFolder folder) {
			this.OSAPI = OSAPI;
			this.OSContainer = container;
			this.OSFolder = folder;

			HubicDriveForm form = this.GetForm();

			this.Items.Clear();
			form.downloadToolButton.Enabled = true;

			ListViewItem item;
			ListViewItem.ListViewSubItem[] subItems;

			OSFile file;
			foreach (KeyValuePair<string, OSFile> entry in this.OSFolder.Files) {
				file = entry.Value;

				item = new ListViewItem(file.Name, 1);
				item.Tag = file;
				subItems = new ListViewItem.ListViewSubItem[] {
					new ListViewItem.ListViewSubItem(item, file.Size),
					new ListViewItem.ListViewSubItem(item, file.LastModified)
				};

				item.SubItems.AddRange(subItems);
				this.Items.Add(item);
			}

			this.Enabled = true;
		}


		public OSFile GetSelectedFile() {
			return (OSFile) this.SelectedItems[0].Tag;
		}


		public void DownloadSelected() {
			if (this.SelectedItems.Count == 0)
				return;

			HubicDriveForm form = this.GetForm();

			if (this.SelectedItems.Count == 1) {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Save as..";

				OSFile selectedFile = this.GetSelectedFile();
				sfd.FileName = selectedFile.Name;

				if (sfd.ShowDialog() == DialogResult.OK) {
					form.queueForm.Add(this.OSContainer.Name, selectedFile.Path, sfd.FileName, selectedFile.Size, "download");
					form.queueForm.Show();
				}

			} else {
				FolderBrowserDialog fbd = new FolderBrowserDialog();

				if (fbd.ShowDialog() == DialogResult.OK) {
					foreach (ListViewItem fileItem in this.SelectedItems) {
						OSFile selectedFile = (OSFile) fileItem.Tag;
						form.queueForm.Add(this.OSContainer.Name, selectedFile.Path, fbd.SelectedPath + "\\" + selectedFile.Name, selectedFile.Size, "download");
					}

					form.queueForm.Show();
				}
			}
		}


		public async void DeleteSelected() {
			if (this.SelectedItems.Count == 0)
				return;

			HubicDriveForm form = this.GetForm();

			foreach (ListViewItem selectedItem in this.SelectedItems) {
				OSFile selectedFile = (OSFile) selectedItem.Tag;

				form.GetConnectionStatus().SetStatus("Status: deleting file " + selectedFile.Name + "...", true);

				string path = this.OSContainer.Name + "/" + selectedFile.Path;

				if (!await OSAPI.DeleteObject(path)) {
					MessageBox.Show("Failed deleting the file " + selectedFile.Name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					form.GetConnectionStatus().SetStatus("Status: connected");
					return;
				}

				this.Items.Remove(selectedItem);
				this.OSFolder.Files.Remove(selectedFile.Name);
				form.GetConnectionStatus().SetStatus("Status: connected");
			}
		}


		public void FileSelectedIndexChanged_Click(object sender, EventArgs e) {
			HubicDriveForm form = this.GetForm();

			form.downloadToolButton.Enabled = true;
		}
	}
}
