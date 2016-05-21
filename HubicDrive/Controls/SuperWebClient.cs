using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace HubicDrive.Controls {
	public class SuperWebClient {
		private NameValueCollection Values = new NameValueCollection();
		private NameValueCollection Files = new NameValueCollection();
		private long BytesTransfered = 0;
		private string Boundary;
		private string Trail;


		public SuperWebClient() {
		}


		public void AddValue(string name, string value) {
			this.Values.Add(name, value);
		}


		public void AddFile(string name, string file) {
			this.Files.Add(name, file);
		}


		public Task<HttpResponseMessage> MultipartUploadTaskAsync(string url) {
			//https://blogs.msdn.microsoft.com/johan/2006/11/15/are-you-getting-outofmemoryexceptions-when-uploading-large-files/

			using (HttpClient client = new HttpClient()) {
				using (MultipartFormDataContent content = new MultipartFormDataContent()) {
					string value;

					foreach (string name in this.Values) {
						value = this.Values[name];
						content.Add(new StringContent(value), name);
					}

					MessageBox.Show("reading files");

					//StreamContent fileContent;
					foreach (string name in this.Files) {
						value = this.Values[name];

						ByteArrayContent fileStream = new ByteArrayContent(File.ReadAllBytes(value));
						fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
						content.Add(fileStream, name, value);
					}
					MessageBox.Show("running post");
					MessageBox.Show(url);

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

					return client.PostAsync(url, content);
				}
			}
		}
		/*
		public delegate void TransferProgressChangedHandler(object o, SWCTransferProgressChangedEventArgs e);
		public event TransferProgressChangedHandler TransferProgressChanged;

		public delegate void TransferCompletedHandler(object o, SWCTransferCompletedEventArgs e);
		public event TransferCompletedHandler TransferCompleted;


		public void OnTransferProgressChanged() {
			if (this.TransferProgressChanged != null)
				this.TransferProgressChanged.Invoke(this, new SWCTransferProgressChangedEventArgs(this.BytesTransfered, this.Request.ContentLength));
		}


		private void OnTransferCompleted() {
			if (this.TransferCompleted != null)
				this.TransferCompleted.Invoke(this, new SWCTransferCompletedEventArgs());
		}*/
	}
}
