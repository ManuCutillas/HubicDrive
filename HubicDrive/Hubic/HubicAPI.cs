using System;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using HubicDrive.Controls;
using System.Diagnostics;

namespace HubicDrive.Hubic {
	public class HubicAPI {
		private string Login = null;
		private string Password = null;
		private readonly string ClientId = "api_hubic_Whv005ooGyoXATgXAw77MmL5KuEfrf7Y";
		private string RefreshToken = null;
		private readonly string ClientSecret = "8pXxSAHJ0C4ieLfX4pxwEJabaGZjj2Ci5kPloYauRdgW0IcElIlSiwiljB4zzPs1";
		private string BaseUrl = "https://api.hubic.com/";
		private ConnectionStatus ConnectionStatus;


		public HubicAPI(string login, string password, ConnectionStatus connectionStatus = null) {
			this.Login = login;
			this.Password = password;
			this.ConnectionStatus = connectionStatus;
		}


		private string GetOAuthID() {
			SuperWebClient swc = new SuperWebClient();

			swc.MaxTries = 10;
			swc.AllowAutoRedirect = false;

			swc.Values.Add("client_id", this.ClientId);
			swc.Values.Add("redirect_uri", "http://localhost:8081/");
			swc.Values.Add("scope", "credentials.r");
			swc.Values.Add("response_type", "code");
			swc.Values.Add("state", "RandomString");

			string html = swc.DownloadString(this.BaseUrl + "oauth/auth/?" + swc.GetQuery());
			Match match = Regex.Match(html, @"name=""oauth"" value=""(\d+)""", RegexOptions.IgnoreCase);

			if (this.ConnectionStatus != null)
				this.ConnectionStatus.SetStatus("Status: connecting...", 20);

			swc.Dispose();

			return match.Groups[1].Value;
		}


		private string GetCode() {
			SuperWebClient swc = new SuperWebClient();

			swc.MaxTries = 10;
			swc.AllowAutoRedirect = false;

			swc.Values.Add("credentials", "r");
			swc.Values.Add("oauth", this.GetOAuthID());
			swc.Values.Add("action", "accepted");
			swc.Values.Add("login", this.Login);
			swc.Values.Add("user_pwd", this.Password);

			swc.UploadValues(this.BaseUrl + "oauth/auth/", swc.Values);

			Match match = Regex.Match(swc.RedirectUrl, @"code=(\w+)&", RegexOptions.IgnoreCase);

			if (this.ConnectionStatus != null)
				this.ConnectionStatus.SetStatus("Status: connecting...", 40);

			swc.Dispose();

			return match.Groups[1].Value;
		}


		private string GetAccessToken() {
			SuperWebClient swc = new SuperWebClient();
			swc.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.ClientId + ":" + this.ClientSecret));

			swc.MaxTries = 10;
			swc.AllowAutoRedirect = false;
			swc.UseDefaultCredentials = true;
			swc.Credentials = new NetworkCredential(this.ClientId, this.ClientSecret);

			if (this.RefreshToken == null) {
				swc.Values.Add("code", this.GetCode());
				swc.Values.Add("redirect_uri", "http://localhost:8081/");
				swc.Values.Add("grant_type", "authorization_code");

			} else {
				swc.Values.Add("refresh_token", this.RefreshToken);
				swc.Values.Add("grant_type", "refresh_token");
			}

			string response = System.Text.Encoding.Default.GetString(swc.UploadValues(this.BaseUrl + "oauth/token/", swc.Values));

			swc.Dispose();

			JObject jsonObject = JObject.Parse(response);

			if (this.RefreshToken == null)
				this.RefreshToken = (string) jsonObject.SelectToken("refresh_token");

			if (this.ConnectionStatus != null)
				this.ConnectionStatus.SetStatus("Status: connecting...", 80);

			return (string) jsonObject.SelectToken("access_token");
		}


		public JObject getCredentials() {
			SuperWebClient swc = new SuperWebClient();
			swc.Headers[HttpRequestHeader.Authorization] = "Bearer " + this.GetAccessToken();

			string response = swc.DownloadString(this.BaseUrl + "1.0/account/credentials");

			swc.Dispose();

			return JObject.Parse(response);
		}

		
		public HubicSignature GetSignature(string container, string remotePath, string localPath) {
			using (HubicWebClient wc = new HubicWebClient()) {
				int maxTires = 10;

				for (int tries = 0; tries < maxTires; tries ++) {
					try {
						wc.Headers.Add("Accept-Encoding", "Accept-Encoding: gzip, deflate, br");
						wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0");
						wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

						string response = wc.UploadString("https://hubic.com/home/logcheck.php", "sign-in-email=" + WebUtility.UrlEncode(this.Login) + "&sign-in-password=" + WebUtility.UrlEncode(this.Password));

						string token = Regex.Match(response, @"prepareUpload\\/"",""token"":""(\w+)""").Groups[1].Value;
						long timestamp = (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
						string data = "max_file_size=" + new FileInfo(localPath).Length;
						data += "&max_file_count=1";
						data += "&expires=" + ((timestamp + 3600) * 1000).ToString();
						data += "&path=" + WebUtility.UrlEncode("/" + container + "/" + (remotePath.Length > 0? remotePath + "/" : ""));
						data += "&redirect=";
						data += "&name=" + WebUtility.UrlEncode(Path.GetFileName(localPath));

						wc.Headers.Add("Accept-Encoding", "Accept-Encoding: gzip, deflate, br");
						wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0");
						wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
						wc.Headers.Add("X-Token", token);

						JObject jsonObject = JObject.Parse(wc.UploadString("https://hubic.com/home/browser/prepareUpload/", data));

						return new HubicSignature(jsonObject["answer"]["hubic"]["signature"].ToString(), jsonObject["answer"]["hubic"]["max_file_size"].ToString(), jsonObject["answer"]["hubic"]["expires"].ToString());

					} catch (Exception) {
					}
				}
			}

			return null;
		}
	}
}
