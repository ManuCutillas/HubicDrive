using System;
using System.Net;

namespace HubicDrive.Hubic {
	class HubicWebClient : WebClient {
		public CookieCollection Cookies { get; private set; } = new CookieCollection();
		private CookieContainer SessionCookies = new CookieContainer();


		protected override WebRequest GetWebRequest(Uri address) {
			var request = (HttpWebRequest) base.GetWebRequest(address);
			request.CookieContainer = this.SessionCookies;

			return request;
		}


		protected override WebResponse GetWebResponse(WebRequest request) {
			var response = (HttpWebResponse) base.GetWebResponse(request);
			this.Cookies = response.Cookies;

			return response;
		}
	}
}
