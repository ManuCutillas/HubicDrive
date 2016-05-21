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
		private string login = null;
		private string password = null;
		private readonly string clientId = "api_hubic_Whv005ooGyoXATgXAw77MmL5KuEfrf7Y";
		private string authorization = null;
		private string code = null;
		private string refreshToken = null;
		private readonly string clientSecret = "8pXxSAHJ0C4ieLfX4pxwEJabaGZjj2Ci5kPloYauRdgW0IcElIlSiwiljB4zzPs1";
		private string baseUrl = "https://api.hubic.com/";
		public string accessToken = null;
		private ConnectionStatus connectionStatus;


		public HubicAPI(string login, string password, ConnectionStatus connectionStatus = null) {
			this.login = login;
			this.password = password;
			this.connectionStatus = connectionStatus;
		}


		private string getOAuthID() {
			string parameters = "client_id=" + this.clientId;
			parameters += "&redirect_uri=http%3A%2F%2Flocalhost%3A8081%2F";
			parameters += "&scope=credentials.r";
			parameters += "&response_type=code";
			parameters += "&state=RandomString";

			HttpWebRequest request;
			HttpWebResponse response;
			StreamReader sReader;
			string html;
			Match match;

			int max_tries = 10;
			for (int tries = 0; tries < max_tries; tries++) {
				try {
					request = (HttpWebRequest) WebRequest.Create(baseUrl + "oauth/auth/?" + parameters);
					request.Timeout = 4000;

					response = (HttpWebResponse) request.GetResponse();

					using (sReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
						html = sReader.ReadToEnd();
					}

					response.Close();

					match = Regex.Match(html, @"name=""oauth"" value=""(\d+)""", RegexOptions.IgnoreCase);

					if (this.connectionStatus != null)
						this.connectionStatus.SetStatus("Status: connecting...", 20);

					return match.Groups[1].Value;

				} catch (WebException e) {
					if (this.connectionStatus != null)
						this.connectionStatus.SetStatus("Status: connecting...", (int) tries * 20 / max_tries);

					if (tries == max_tries - 1)
						MessageBox.Show("Unable to get OAuth ID", "Problem connecting to Hubic", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			return null;
		}


		private string getCode() {
			if (this.code != null)
				return this.code;

			string parameters = "credentials=r";
			parameters += "&oauth=" + this.getOAuthID();
			parameters += "&action=accepted";
			parameters += "&login=" + this.login;
			parameters += "&user_pwd=" + this.password;

			byte[] data = Encoding.ASCII.GetBytes(parameters);

			HttpWebRequest request;
			Stream stream;
			HttpWebResponse response;
			string redirectURL;
			Match match;

			for (int tries = 0; tries < 5 && this.code == null; tries++) {
				try {
					request = (HttpWebRequest) WebRequest.Create(this.baseUrl + "oauth/auth/");
					request.Method = "POST";
					request.ContentType = "application/x-www-form-urlencoded";
					request.AllowAutoRedirect = false;
					request.ContentLength = data.Length;

					using (stream = request.GetRequestStream()) {
						stream.Write(data, 0, data.Length);
					}

					response = (HttpWebResponse) request.GetResponse();
					redirectURL = response.Headers["Location"];
					response.Close();

					match = Regex.Match(redirectURL, @"code=(\w+)&", RegexOptions.IgnoreCase);

					this.code = match.Groups[1].Value;

				} catch (WebException e) {
					if (this.connectionStatus != null)
						this.connectionStatus.SetStatus("Connecting...", tries * 5 + 20);

					if (tries == 4)
						MessageBox.Show("Unable to get the auth code", "Problem connecting to Hubic", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			if (this.connectionStatus != null && this.code != null)
				this.connectionStatus.SetStatus("Status: connecting...", 40);

			return this.code;
		}


		private string getAuthorization() {
			if (this.authorization != null)
				return this.authorization;

			this.authorization = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(this.clientId + ":" + this.clientSecret));

			if (this.connectionStatus != null)
				this.connectionStatus.SetStatus("Status: connecting...", 60);

			return this.authorization;
		}


		private string getAccessToken() {
			string parameters = "";

			if (this.refreshToken == null) {
				parameters = "code=" + this.getCode();
				parameters += "&redirect_uri=http%3A%2F%2Flocalhost%3A8081%2F";
				parameters += "&grant_type=authorization_code";

			} else {
				parameters = "refresh_token=" + this.refreshToken;
				parameters += "&grant_type=refresh_token";
			}

			byte[] data = Encoding.UTF8.GetBytes(parameters);

			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.baseUrl + "oauth/token/");
			request.Headers[HttpRequestHeader.Authorization] = "Basic " + this.getAuthorization();
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.AllowAutoRedirect = false;
			request.ContentLength = data.Length;

			using (Stream stream = request.GetRequestStream()) {
				stream.Write(data, 0, data.Length);
			}

			HttpWebResponse response = (HttpWebResponse) request.GetResponse();

			JObject jsonResponse = new JObject();
			using (StreamReader sReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
				jsonResponse = JObject.Parse(sReader.ReadToEnd());
			}

			response.Close();

			if (this.refreshToken == null)
				this.refreshToken = (string) jsonResponse.SelectToken("refresh_token");

			if (this.connectionStatus != null)
				this.connectionStatus.SetStatus("Status: connecting...", 80);

			return (string) jsonResponse.SelectToken("access_token");
		}


		public string getCredentials() {
			string accessToken = this.getAccessToken();

			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.baseUrl + "1.0/account/credentials");
			request.Headers[HttpRequestHeader.Authorization] = "Bearer " + this.getAccessToken();

			HttpWebResponse response = (HttpWebResponse) request.GetResponse();

			string credentials;
			using (StreamReader sReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
				credentials = sReader.ReadToEnd();
			}

			response.Close();

			if (this.connectionStatus != null)
				this.connectionStatus.SetStatus("Status: connecting...", 100);

			return credentials;
		}

		
		public HubicSignature GetSignature(string container, string remotePath, string localPath) {
			using (HubicWebClient wc = new HubicWebClient()) {
				int maxTires = 10;

				for (int tries = 0; tries < maxTires; tries ++) {
					try {
						wc.Headers.Add("Accept-Encoding", "Accept-Encoding: gzip, deflate, br");
						wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0");
						wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

						string response = wc.UploadString("https://hubic.com/home/logcheck.php", "sign-in-email=" + WebUtility.UrlEncode(this.login) + "&sign-in-password=" + WebUtility.UrlEncode(this.password));

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

					} catch (Exception e) {
					}
				}
			}

			return null;
		}
	}
}
