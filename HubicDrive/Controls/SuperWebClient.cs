using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubicDrive.Controls {
	public class SuperWebClient : WebClient {
		private Uri Uri { get; set; }

		public CookieCollection Cookies { get; private set; } = new CookieCollection();
		private CookieContainer SessionCookies = new CookieContainer();

		public NameValueCollection Values = new NameValueCollection();
		public NameValueCollection Files = new NameValueCollection();

		public int Timeout { get; set; } = 10;
		public int Tries { get; set; } = 0;
		public int MaxTries { get; set; } = 1;
		public bool AllowAutoRedirect { get; set; } = true;
		public string RedirectUrl { get; private set; }


		public string GetQuery() {
			string query = "";

			foreach (string key in this.Values)
				query += WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(this.Values[key]) + "&";

			return query.Substring(0, query.Length - 1);
		}


		protected override WebRequest GetWebRequest(Uri uri) {
			HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(uri);

			request.CookieContainer = this.SessionCookies;
			request.Timeout = this.Timeout * 1000;
			request.AllowAutoRedirect = this.AllowAutoRedirect;

			return request;
		}


		protected override WebResponse GetWebResponse(WebRequest request) {
			try {
				HttpWebResponse response = (HttpWebResponse) base.GetWebResponse(request);
				this.Cookies = response.Cookies;
				this.RedirectUrl = response.Headers["Location"];

				return response;

			} catch (WebException) {
				this.Tries++;

				if (this.Tries < this.MaxTries)
					this.GetWebResponse(request);

				throw;
			}
		}
	}
}
