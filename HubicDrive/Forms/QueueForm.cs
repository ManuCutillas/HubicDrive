using HubicDrive.Controls;
using System;
using System.Windows.Forms;
using HubicDrive.OpenStack;
using HubicDrive.Hubic;
using System.Collections;

namespace HubicDrive.Forms {
	public partial class QueueForm : Form {
		public HubicAPI HAPI;
		public OpenStackAPI OSAPI;
		private string Status = "stopped";
		private int MaxSimultaneousTransfers = 5;


		public QueueForm(HubicAPI HAPI, OpenStackAPI OSAPI) {
			this.HAPI = HAPI;
			this.OSAPI = OSAPI;

			InitializeComponent();
		}


		public void Add(string container, string remotePath, string localPath, long bytes, string direction) {
			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if ((queueItem.Container == container && queueItem.RemotePath == remotePath) && (direction == "download" || queueItem.LocalPath == localPath))
					return;
			}

			this.queueListView.Items.Add(new QueueListViewItem(container, remotePath, localPath, bytes, direction));

			this.UpdateStatus();
		}


		private void Remove(int index) {
			this.queueListView.Items[index].Remove();
		}


		private void RemoveSelected(object sender, EventArgs e) {
			foreach (QueueListViewItem queueItem in this.queueListView.SelectedItems) {
				this.Remove(queueItem.Index);
			}

			this.UpdateStatus();
		}


		public void RemoveFinished(object sender, EventArgs e) {
			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if (queueItem.Status == "finished")
					this.Remove(queueItem.Index);
			}

			this.UpdateStatus();
		}


		public void Start(object sender, EventArgs e) {
			int transfersRunning = 0;

			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if (queueItem.Status == "running")
					transfersRunning++;
			}

			if (transfersRunning >= this.MaxSimultaneousTransfers)
				return;

			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if (sender.ToString() == "Selected" && queueItem.Selected == false)
					continue;

				if (queueItem.Status == "stopped" && transfersRunning < this.MaxSimultaneousTransfers) {
					queueItem.Start();
					transfersRunning++;
				}
			}

			this.UpdateStatus();
		}


		public void Stop(object sender, EventArgs e) {
			if (this.Status == "stopped")
				return;

			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if (queueItem.Status == "running")
					queueItem.Stop();
			}

			this.Status = "stopped";
		}


		public void UpdateStatus() {
			this.Status = "stopped";

			int transfersFinished = 0;
			this.queueStripProgressBar.Maximum = this.queueListView.Items.Count;

			foreach (QueueListViewItem queueItem in this.queueListView.Items) {
				if (queueItem.Status == "running")
					this.Status = "running";

				else if (queueItem.Status == "finished")
					transfersFinished++;
			}

			if (transfersFinished == this.queueListView.Items.Count) {
				this.queueStripStatusLabel.Text = "All transfers finished";
				this.queueStripProgressBar.Visible = false;

			} else {
				this.queueStripStatusLabel.Text = this.queueListView.Items.Count.ToString() + " transfers in total ";
				this.queueStripProgressBar.Value = transfersFinished;
				this.queueStripProgressBar.Visible = this.Status == "running";
			}
		}


		private void MaxSimultaneousTransfers_ValueChanged(object sender, EventArgs e) {
			this.MaxSimultaneousTransfers = Convert.ToInt32(this.maxSimultaneousTransfersNumericUpDown.Value);
		}


		private void QueueForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				Hide();
			}
		}
	}
}
