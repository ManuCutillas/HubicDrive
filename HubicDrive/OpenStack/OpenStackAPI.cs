using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using HubicDrive.Hubic;
using System.IO;
using HubicDrive.Controls;

namespace HubicDrive.OpenStack {
	public class OpenStackAPI {
		private string token;
		private string endpoint;
		private string expires;


		public OpenStackAPI(HubicAPI HAPI) {
			JObject credentials = JObject.Parse("{\"token\":\"33b96f08ae284411a138da6b85f43c9e\",\"endpoint\":\"https://lb9911.hubic.ovh.net/v1/AUTH_6f5b4a82af3682dfb7a8034f78e8dcb1\",\"expires\":\"2016-05-14T20:16:03+02:00\"}");
			//JObject credentials = JObject.Parse(HAPI.getCredentials());
			Debug.WriteLine(credentials.ToString());

			this.token = (string) credentials.SelectToken("token");
			this.endpoint = (string) credentials.SelectToken("endpoint");
			this.expires = (string) credentials.SelectToken("expires");
		}


		public async Task<bool> CreateObject(string container, string remotePath = null) {
			using (WebClient wc = new WebClient()) {
				wc.Headers.Add("X-Auth-Token", this.token);

				if (remotePath != null)
					wc.Headers.Add("Content-Type", "application/directory");

				string url = this.endpoint + "/" + WebUtility.UrlEncode(container);

				if (remotePath != null && remotePath.Length > 0)
					url += WebUtility.UrlEncode(remotePath);

				try {
					await wc.UploadStringTaskAsync(url, "PUT", "");

				} catch (WebException e) {
					MessageBox.Show(e.ToString());
					return false;
				}

				return true;
			}
		}


		public async Task<SuperWebClient> UploadObject(string container, string remotePath, string localPath, string signature, string maxFileSize, string expires, Action<object, SWCTransferProgressChangedEventArgs> transferProgressChangedCallback, Action<object, SWCTransferCompletedEventArgs> transferCompletedCallback) {
			SuperWebClient mwc = new SuperWebClient();
/*
			mwc.TransferProgressChanged += new SuperWebClient.TransferProgressChangedHandler(transferProgressChangedCallback);
			mwc.TransferCompleted += new SuperWebClient.TransferCompletedHandler(transferCompletedCallback);
			*/
			mwc.AddValue("max_file_size", maxFileSize);
			mwc.AddValue("max_file_count", "1");
			mwc.AddValue("expires", expires);
			mwc.AddValue("redirect", "");
			mwc.AddValue("signature", signature);
			mwc.AddValue("name", Path.GetFileName(localPath));
			mwc.AddFile("file1", localPath);

			await mwc.MultipartUploadTaskAsync(this.endpoint + "/" + container + "/" + remotePath);

			return mwc;
		}

		/*
		public WebClient UploadObject(string container, string remotePath, string localPath, string signature, string maxFileSize, string expires, Action<object, UploadProgressChangedEventArgs> uploadProgressChangedCallback, Action<object, UploadFileCompletedEventArgs> uploadCompletedCallback) {
			using (WebClient wc = new WebClient()) {
				wc.Headers.Add("X-Auth-Token", this.token);

				wc.UploadProgressChanged += new UploadProgressChangedEventHandler(uploadProgressChangedCallback);
				wc.UploadFileCompleted += new UploadFileCompletedEventHandler(uploadCompletedCallback);

				string url = this.endpoint + "/" + container + "/" + remotePath;
				wc.UploadFileTaskAsync(url, "PUT", localPath);

				return wc;
			}
		}
		*/

		public WebClient DownloadObject(string container, string remotePath, string localPath, Action<object, DownloadProgressChangedEventArgs> downloadProgressChangedCallback, Action<object, AsyncCompletedEventArgs> downloadCompletedCallback) {
			using (WebClient wc = new WebClient()) {
				wc.Headers.Add("X-Auth-Token", this.token);

				wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgressChangedCallback);
				wc.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadCompletedCallback);
				string url = this.endpoint + "/" + container + "/" + remotePath;

				wc.DownloadFileTaskAsync(url, localPath);

				return wc;
			}
		}


		public async Task<JArray> GetObjects(string container = null, string remotePath = null) {
			using (WebClient wc = new WebClient()) {
				wc.Headers.Add("X-Auth-Token", this.token);

				string url = this.endpoint;

				if (container != null)
					url += "/" + container;

				url += "?format=json";

				if (remotePath != null)
					url += "&path=" + WebUtility.UrlEncode(remotePath);

				return JArray.Parse(await wc.DownloadStringTaskAsync(url));
			}
		}


		public async Task<bool> DeleteObject(string remotePath) {
			using (WebClient wc = new WebClient()) {
				wc.Headers.Add("X-Auth-Token", this.token);

				try {
					await wc.UploadStringTaskAsync(this.endpoint + "/" + remotePath, "DELETE", "");

				} catch (WebException e) {
					MessageBox.Show(this.endpoint + "/" + remotePath);
					MessageBox.Show(e.ToString());
					return false;
				}
			}

			return true;
		}
	}
}
