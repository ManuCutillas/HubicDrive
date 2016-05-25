using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubicDrive.Controls {
	public class SuperWebClient {
		private NameValueCollection Values = new NameValueCollection();
		private NameValueCollection Files = new NameValueCollection();
		public ProgressMessageHandler progressHandler = new ProgressMessageHandler();

		public void AddValue(string name, string value) {
			this.Values.Add(name, value);
		}


		public void AddFile(string name, string file) {
			this.Files.Add(name, file);
		}


		public async Task<HttpResponseMessage> MultipartUploadTaskAsync(string url) {
			//https://blogs.msdn.microsoft.com/johan/2006/11/15/are-you-getting-outofmemoryexceptions-when-uploading-large-files/
			Control.CheckForIllegalCrossThreadCalls = false;

			//HttpClientHandler handler = new HttpClientHandler();

//			ProgressMessageHandler progressHandler = new ProgressMessageHandler();
//			progressHandler.HttpSendProgress += this.OnTransferProgressChanged;

			using (HttpClient client = HttpClientFactory.Create(progressHandler)) {
				client.Timeout = TimeSpan.FromDays(5);

				using (MultipartFormDataContent content = new MultipartFormDataContent()) {
					string value;

					foreach (string name in this.Values) {
						value = this.Values[name];

						content.Add(new StringContent(value), name);
					}

					foreach (string name in this.Files) {
						value = this.Files[name];

						StreamContent fileStream = new StreamContent(new FileStream(value, FileMode.Open, FileAccess.Read));
						fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
						content.Add(fileStream, name, Path.GetFileName(value));
					}

					HttpRequestHeaders headers = client.DefaultRequestHeaders;
					headers.ExpectContinue = false;
					headers.TryAddWithoutValidation("Connection", "keep-alive");
					headers.TryAddWithoutValidation("Origin", "https://hubic.com");
					headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Maxthon/4.4.8.2000 Chrome/30.0.1599.101 Safari/537.36");
					headers.TryAddWithoutValidation("Accept", "*/*");
					headers.TryAddWithoutValidation("DNT", "1");
					headers.TryAddWithoutValidation("Referer", "https://hubic.com/home/browser/");
					headers.TryAddWithoutValidation("Accept-Encoding", "gzip,deflate");
					headers.TryAddWithoutValidation("Accept-Language", "es-ES");

					HttpResponseMessage response = await client.PostAsync(url, content);
					this.OnTransferCompleted();

					return response;
				}
			}
		}

		public delegate void TransferProgressChangedHandler(object o, SWCTransferProgressChangedEventArgs e);
		public event TransferProgressChangedHandler TransferProgressChanged;

		public delegate void TransferCompletedHandler(object o, SWCTransferCompletedEventArgs e);
		public event TransferCompletedHandler TransferCompleted;


		private void OnTransferProgressChanged(object sender, HttpProgressEventArgs e) {
			if (this.TransferProgressChanged != null)
				this.TransferProgressChanged.Invoke(this, new SWCTransferProgressChangedEventArgs(e.BytesTransferred, (long) e.TotalBytes));
		}
		

		private void OnTransferCompleted() {
			if (this.TransferCompleted != null)
				this.TransferCompleted.Invoke(this, new SWCTransferCompletedEventArgs());
		}
	}
}
