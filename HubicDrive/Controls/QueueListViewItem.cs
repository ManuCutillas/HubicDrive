using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using HubicDrive.Forms;
using System.IO;
using HubicDrive.Hubic;
using System.Net.Http.Handlers;

namespace HubicDrive.Controls {
	public partial class QueueListViewItem : ListViewItem {
		private string _Container;
		public string Container {
			get {
				return this._Container;
			}

			private set {
				this._Container = value;
				this.Text = this.Container;
			}
		}

		private string _RemotePath;
		public string RemotePath {
			get {
				return this._RemotePath;
			}

			private set {
				this._RemotePath = value;
				this.SubItems["remotePath"].Text = this.RemotePath;
			}
		}

		private string _LocalPath;
		public string LocalPath {
			get {
				return this._LocalPath;
			}

			private set {
				this._LocalPath = value;
				this.SubItems["localPath"].Text = this.LocalPath;
				this.SubItems["remotePath"].Text = (this.RemotePath.Length > 0 ? this.RemotePath + "/" : "") + Path.GetFileName(this.LocalPath);
			}
		}

		private string _Size;
		public string Size {
			get {
				return this._Size;
			}

			private set {
				this._Size = value;
				this.SubItems["size"].Text = this.Size;
			}
		}

		private string _Progress;
		public string Progress {
			get {
				return this._Progress;
			}

			private set {
				this._Progress = value;
				this.SubItems["progress"].Text = this.Progress;
			}
		}

		private string _Direction;
		public string Direction {
			get {
				return this._Direction;
			}

			private set {
				this._Direction = value;
				this.SubItems["direction"].Text = this.Direction;
			}
		}

		public string Status { get; private set; } = "stopped";

		private WebClient wc;

		private long LastTransfered = 0;

		private DateTime LastUpdate;


		public QueueListViewItem(string container, string remotePath, string localPath, string size, string direction) {
			ListViewSubItem lvsi;
			foreach (string name in new string[] {"remotePath", "localPath", "size", "progress", "speed", "direction"}) {
				lvsi = new ListViewSubItem();
				lvsi.Name = name;
				this.SubItems.Add(lvsi);
			}

			this.Container = container;
			this.RemotePath = remotePath;
			this.LocalPath = localPath;
			this.Size = size;
			this.Direction = direction;
		}


		public QueueForm GetForm() {
			return (QueueForm) this.ListView.FindForm();
		}


		public async void Start() {
			if (this.Status == "running")
				return;

			this.Status = "running";
			this.Progress = "Connecting...";

			QueueForm form = this.GetForm();

			if (this.Direction == "upload") {
				this.wc = form.OSAPI.UploadObject(this.Container, this.RemotePath, this.LocalPath, this.UploadProgressChanged, this.TransferCompleted);
				//HubicSignature signature = form.HAPI.GetSignature(this.Container, this.RemotePath, this.LocalPath);
				//await form.OSAPI.UploadObject(this.Container, this.RemotePath + "/", this.LocalPath, signature.signature, signature.maxFileSize, signature.expires, this.TransferProgressChanged, this.TransferCompleted);

			} else if (this.Direction == "download") {
				this.wc = form.OSAPI.DownloadObject(this.Container, this.RemotePath, this.LocalPath, this.DownloadProgressChanged, this.TransferCompleted);
			}
		}


		public void Stop() {
			if (this.Status == "stopped")
				return;

			this.wc.CancelAsync();

			this.Progress = "Cancelled";
			this.Status = "stopped";
		}


		private string GetSpeed(long transfered) {
			string speed = Helper.HumanReadableSize((transfered - this.LastTransfered) / (DateTime.Now - this.LastUpdate).Seconds) + "/s";

			this.LastUpdate = DateTime.Now;
			this.LastTransfered = transfered;

			return speed;
		}


		private void UpdateProgress(long transfered, int percentage) {
			if (this.LastUpdate == null)
				this.LastUpdate = DateTime.Now;

			if ((DateTime.Now - this.LastUpdate).Seconds > 1) {
				this.Progress = percentage.ToString();
				this.Progress += "%";

				this.SubItems["speed"].Text = this.GetSpeed(transfered);
			}
		}


		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			this.UpdateProgress(e.BytesReceived, e.ProgressPercentage);
		}


		private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e) {
			this.UpdateProgress(e.BytesSent, e.ProgressPercentage);
		}


		private void TransferProgressChanged(object sender, HttpProgressEventArgs e) {
			this.UpdateProgress(e.BytesTransferred, e.ProgressPercentage);
		}


		private void TransferCompleted(object sender, SWCTransferCompletedEventArgs e) {
			if (e.Cancelled) {
				this.Progress = "Cancelled";
				this.SubItems["speed"].Text = "";
				return;
			}

			if (e.Error != null) {
				this.Progress = "Error";
				this.SubItems["speed"].Text = "";
				return;
			}

			this.Progress = "Finished";
			this.SubItems["speed"].Text = "";
			this.Status = "finished";

			QueueForm queueForm = this.GetForm();
			queueForm.Start(new object(), new EventArgs());
			queueForm.UpdateStatus();
		}

		private void TransferCompleted(object sender, AsyncCompletedEventArgs e) {
			this.SubItems["speed"].Text = "";
			this.Status = "stopped";
			this.wc.Dispose();

			if (e.Cancelled) {
				this.Progress = "Cancelled";
				return;
			}

			if (e.Error != null) {
				MessageBox.Show(e.Error.ToString());
				this.Progress = "Error";
				this.Start();
				return;
			}

			this.Progress = "Finished";
			this.Status = "finished";

			QueueForm queueForm = this.GetForm();
			queueForm.Start(new object(), new EventArgs());
			queueForm.UpdateStatus();
		}
	}
}
