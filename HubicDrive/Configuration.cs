using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace HubicDrive {
	class Configuration {
		byte[] entropy = Encoding.UTF8.GetBytes("ashui34ASDF·$%%&YDSGwq)/%!/rq5&(4asdgASET");
		DataProtectionScope scope = DataProtectionScope.CurrentUser;


		public string Get(string name, string defaultValue = null, bool encrypted = false) {
			NameValueCollection settings = ConfigurationManager.AppSettings;

			try {
				if (settings[name] != null)
					return encrypted ? this.Decrypt(settings[name]) : settings[name];

			} catch (Exception e) {
				return "";
			}

			return defaultValue;
		}


		public void Set(string name, string value, bool encrypted = false) {
			System.Configuration.Configuration file = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			KeyValueConfigurationCollection settings = file.AppSettings.Settings;

			if (settings[name] == null) {
				settings.Add(name, value);

			} else {
				settings[name].Value = encrypted ? this.Encrypt(value) : value;
			}

			file.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(file.AppSettings.SectionInformation.Name);
		}


		private string Encrypt(string text) {
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			byte[] encrypted = ProtectedData.Protect(bytes, this.entropy, this.scope);
			return Convert.ToBase64String(encrypted);
		}


		private string Decrypt(string text) {
			byte[] bytes = Convert.FromBase64String(text);
			byte[] unencripted = ProtectedData.Unprotect(bytes, this.entropy, this.scope);
			return Encoding.UTF8.GetString(unencripted);
		}
	}
}
