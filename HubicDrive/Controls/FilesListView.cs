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


		public FilesListView() {
			this.SelectedIndexChanged += this.SelectChanged;
		}


		public HubicDriveForm GetForm() {
			return (HubicDriveForm) this.FindForm();
		}


		public void Load(OpenStackAPI OSAPI, OSContainer container, OSFolder folder) {
			this.OSAPI = OSAPI;
			this.OSContainer = container;
			this.OSFolder = folder;

			HubicDriveForm form = this.GetForm();

			this.Items.Clear();

			ListViewItem item;

			OSFile file;
			foreach (KeyValuePair<string, OSFile> entry in this.OSFolder.Files) {
				file = entry.Value;

				item = new ListViewItem(file.Name, 1);
				item.Tag = file;
				item.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
					new ListViewItem.ListViewSubItem(item, file.Size),
					new ListViewItem.ListViewSubItem(item, file.LastModified)
				});

				this.Items.Add(item);
			}

			this.Enabled = true;
		}


		public void SelectChanged(object sender, EventArgs e) {
			HubicDriveForm form = this.GetForm();

			form.downloadToolButton.Enabled = this.SelectedItems.Count > 0;
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
					form.queueForm.Add(this.OSContainer.Name, selectedFile.Path, sfd.FileName, selectedFile.Bytes, "download");
					form.queueForm.Show();
				}

			} else {
				FolderBrowserDialog fbd = new FolderBrowserDialog();

				if (fbd.ShowDialog() == DialogResult.OK) {
					OSFile selectedFile;

					foreach (ListViewItem fileItem in this.SelectedItems) {
						selectedFile = (OSFile) fileItem.Tag;
						form.queueForm.Add(this.OSContainer.Name, selectedFile.Path, fbd.SelectedPath + "\\" + selectedFile.Name, selectedFile.Bytes, "download");
					}

					form.queueForm.Show();
				}
			}
		}


		public async void DeleteSelected() {
			HubicDriveForm form = this.GetForm();
			OSFile selectedFile;

			foreach (ListViewItem selectedItem in this.SelectedItems) {
				selectedFile = (OSFile) selectedItem.Tag;

				form.GetConnectionStatus().SetStatus("Status: deleting file " + selectedFile.Name + "...", true);

				if (!await OSAPI.DeleteObject(this.OSContainer.Name, selectedFile.Path)) {
					MessageBox.Show("Failed deleting the file " + selectedFile.Name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					break;
				}

				this.Items.Remove(selectedItem);
				this.OSFolder.Files.Remove(selectedFile.Name);
			}

			form.GetConnectionStatus().SetStatus("Status: connected");
		}
	}
}
