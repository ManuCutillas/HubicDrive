using HubicDrive.OpenStack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HubicDrive.Forms;

namespace HubicDrive.Controls {
	public class ContainersComboBox : ComboBox {
		private OpenStackAPI OSAPI;
		private Dictionary<string, OSContainer> OSContainers = null;


		public ContainersComboBox() {
			this.SelectedIndexChanged += this.ContainersComboBox_SelectedIndexChanged;
		}


		public HubicDriveForm GetForm() {
			return (HubicDriveForm) this.FindForm();
		}


		public async void Load(OpenStackAPI OSAPI, bool reload = false) {
			this.OSAPI = OSAPI;

			HubicDriveForm form = this.GetForm();

			form.GetConnectionStatus().SetStatus("Status: reading containers...", true);

			OSContainer container;

			if (this.OSContainers == null || reload) {
				this.Items.Clear();

				JArray jsonObjects = await this.OSAPI.GetObjects();

				this.OSContainers = new Dictionary<string, OSContainer>();

				for (int i = 0; i < jsonObjects.Count; i++) {
					container = new OSContainer(
						jsonObjects[i]["count"].ToString(),
						jsonObjects[i]["bytes"].ToString(),
						jsonObjects[i]["name"].ToString()
					);

					this.OSContainers.Add(container.Name, container);

					//if (container.Name.IndexOf("_segments") != -1)
						//continue;

					this.Items.Add(container.Name);
				}
			}

			this.Enabled = true;
			this.SelectedIndex = this.FindStringExact("default");

			form.GetConnectionStatus().SetStatus("Status: connected");
		}


		public async void Create(string name) {
			HubicDriveForm form = this.GetForm();

			form.GetConnectionStatus().SetStatus("Status: creating container "+ name + "...", true);

			if (!await OSAPI.CreateObject(name)) {
				MessageBox.Show("Failed creating the container " + name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				form.GetConnectionStatus().SetStatus("Status: connected");
				return;
			}

			OSContainer container = new OSContainer("0", "0", name);

			this.OSContainers.Add(name, container);
			this.Items.Add(name);
			this.SelectedItem = name;

			form.GetConnectionStatus().SetStatus("Status: connected");
		}


		public async void Delete(bool confirmed = false) {
			if (confirmed == false)
				return;

			HubicDriveForm form = this.GetForm();

			string name = this.GetSelectedContainer().Name;

			form.GetConnectionStatus().SetStatus("Status: deleting container " + name + "...", true);
			
			if (!await OSAPI.DeleteObject(name)) {
				MessageBox.Show("Failed deleting the container " + name, "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				form.GetConnectionStatus().SetStatus("Status: connected");
				return;
			}
			
			this.OSContainers.Remove(name);
			this.Items.Remove(name);
			form.GetFoldersTreeView().Nodes.Clear();
			form.GetFilesListView().Items.Clear();
			form.GetFolderInfoLabel().Visible = false;

			form.GetConnectionStatus().SetStatus("Status: connected");
		}


		public OSContainer GetSelectedContainer() {
			return this.GetContainer((string) this.SelectedItem);
		}


		public OSContainer GetContainer(string name) {
			return this.OSContainers[name];
		}


		public Dictionary<string, OSContainer> GetContainers() {
			return this.OSContainers;
		}


		private void ContainersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			HubicDriveForm form = this.GetForm();

			form.deleteContainerToolButton.Enabled = this.GetSelectedContainer().Name != "default";

			FoldersTreeView foldersTreeView = form.GetFoldersTreeView();
			foldersTreeView.Load(this.OSAPI, this.GetSelectedContainer(), true);
		}
	}
}
