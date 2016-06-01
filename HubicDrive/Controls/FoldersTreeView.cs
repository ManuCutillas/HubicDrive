using HubicDrive.OpenStack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using HubicDrive.Forms;

namespace HubicDrive.Controls {
	public class FoldersTreeView : TreeView {
		private OpenStackAPI OSAPI;
		private OSContainer OSContainer;


		public FoldersTreeView() {
			this.AfterSelect += this.FoldersTreeView_AfterSelect;
		}


		public HubicDriveForm GetForm() {
			return (HubicDriveForm) this.FindForm();
		}


		public void Load(OpenStackAPI OSAPI, OSContainer container, bool reload = false) {
			this.OSAPI = OSAPI;
			this.OSContainer = container;

			if (this.Nodes.Count == 0 || reload) {
				this.Nodes.Clear();

				TreeNode node = new TreeNode(this.OSContainer.Name);
				node.Name = this.OSContainer.Name;
				node.Tag = new OSFolder("", "", "0", "", "");
				this.Nodes.Add(node);
			}

			this.Enabled = true;
			this.SelectedNode = this.Nodes[this.OSContainer.Name];
		}


		public async void Create(string name) {
			HubicDriveForm form = this.GetForm();

			form.GetConnectionStatus().SetStatus("Status: creating folder " + name + "...", true);

			TreeNode selectedNode = this.GetSelectedNode();
			OSFolder selectedFolder = this.GetSelectedFolder();

			if (!await OSAPI.CreateObject(this.OSContainer.Name, selectedFolder.Path + "/" + name)) {
				MessageBox.Show("Failed creating the folder " + name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				form.GetConnectionStatus().SetStatus("Status: connected");
				return;
			}

			OSFolder folder = new OSFolder("", "", "0", selectedFolder.Path + "/" + name, "application/folder");
			selectedFolder.Subfolders.Add(folder.Name, folder);

			TreeNode node = new TreeNode(folder.Name);
			node.Name = folder.Name;
			node.Tag = folder;
			selectedNode.Nodes.Add(node);

			this.SelectedNode = node;

			form.GetConnectionStatus().SetStatus("Status: connected");
		}


		public async void Delete(bool confirmed = false) {
			if (confirmed == false)
				return;

			HubicDriveForm form = this.GetForm();

			TreeNode selectedNode = this.GetSelectedNode();
			OSFolder selectedFolder = this.GetSelectedFolder();

			if (selectedFolder.Name == "") {
				MessageBox.Show("Can not delete root folder, maybe you want to delete container", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				form.GetConnectionStatus().SetStatus("Status: connected");
				return;
			}

			form.GetConnectionStatus().SetStatus("Status: deleting folder " + selectedFolder.Name + "...", true);

			string path = this.OSContainer.Name + "/" + selectedFolder.Path;

			if (!await OSAPI.DeleteObject(path)) {
				MessageBox.Show("Failed deleting the folder " + selectedFolder.Name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				form.GetConnectionStatus().SetStatus("Status: connected");
				return;
			}

			this.Nodes.Remove(selectedNode);
			form.GetFilesListView().Items.Clear();
			form.GetFolderInfoLabel().Visible = false;

			form.GetConnectionStatus().SetStatus("Status: connected");
		}


		public TreeNode GetSelectedNode() {
			return this.SelectedNode;
		}


		public OSFolder GetSelectedFolder() {
			return (OSFolder) this.GetSelectedNode().Tag;
		}


		private async void FoldersTreeView_AfterSelect(Object sender, TreeViewEventArgs e) {
			HubicDriveForm form = this.GetForm();

			TreeNode selectedNode = this.GetSelectedNode();
			OSFolder selectedFolder = this.GetSelectedFolder();

			if (selectedFolder.Loaded == false) {
				form.GetConnectionStatus().SetStatus("Status: reading content...", true);

				selectedFolder.Subfolders = new Dictionary<string, OSFolder>();
				selectedFolder.Files = new Dictionary<string, OSFile>();

				JArray jsonObjects = await this.OSAPI.GetObjects(this.OSContainer.Name, selectedFolder.Path);

				OSFolder folder;
				OSFile file;
				TreeNode node;

				for (int i = 0; i < jsonObjects.Count; i++) {
					if (jsonObjects[i]["content_type"].ToString() == "application/directory") {
						folder = new OSFolder(
							jsonObjects[i]["hash"].ToString(),
							jsonObjects[i]["last_modified"].ToString(),
							jsonObjects[i]["bytes"].ToString(),
							jsonObjects[i]["name"].ToString(),
							jsonObjects[i]["content_type"].ToString()
						);

						selectedFolder.Subfolders.Add(folder.Name, folder);

						node = new TreeNode(folder.Name);
						node.Name = folder.Name;
						node.Tag = folder;
						selectedNode.Nodes.Add(node);

					} else {
						file = new OSFile(
							jsonObjects[i]["hash"].ToString(),
							jsonObjects[i]["last_modified"].ToString(),
							jsonObjects[i]["bytes"].ToString(),
							jsonObjects[i]["name"].ToString(),
							jsonObjects[i]["content_type"].ToString()
						);

						selectedFolder.Bytes += file.Bytes;
						selectedFolder.Files.Add(file.Name, file);
					}
				}

				selectedFolder.Loaded = true;
				selectedNode.Expand();
				form.GetConnectionStatus().SetStatus("Status: connected");
			}

			form.createFolderToolButton.Enabled = true;
			form.deleteFolderToolButton.Enabled = selectedFolder.Name.Length > 0;
			form.uploadToolButton.Enabled = true;

			Label folderInfoLabel = form.GetFolderInfoLabel();
			folderInfoLabel.Visible = true;
			folderInfoLabel.Text = selectedFolder.Files.Count.ToString() + " files (" + selectedFolder.Size + ")";

			FilesListView filesListView = form.GetFilesListView();
			filesListView.Load(this.OSAPI, this.OSContainer, selectedFolder);
		}


		public void Upload() {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckFileExists = false;
			ofd.ValidateNames = false;
			ofd.Multiselect = true;

			if (ofd.ShowDialog() == DialogResult.OK) {
				HubicDriveForm form = this.GetForm();

				foreach (string file in ofd.FileNames)
					form.queueForm.Add(this.OSContainer.Name, this.GetSelectedFolder().Path, file, new FileInfo(file).Length, "upload");

				form.queueForm.Show();
			}
		}
	}
}
