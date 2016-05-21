using System;

namespace HubicDrive.OpenStack {
	public class OSObject {
		public string Hash { get; }

		public string LastModified { get; }

		public long Bytes { get; set; }

		public string Path { get; }

		public string ContentType { get; }

		public string Name {
			get {
				if (this.Path.IndexOf('/') == -1)
					return this.Path;

				return this.Path.Substring(this.Path.LastIndexOf('/') + 1);
			}
		}

		public string Size {
			get {
				return Helper.HumanReadableSize(this.Bytes);
			}
		}


		public OSObject(string hash, string lastModified, string bytes, string path, string contentType) {
			this.Hash = hash;
			this.LastModified = lastModified;
			this.Bytes = Convert.ToInt64(bytes);
			this.Path = path;
			this.ContentType = contentType;
		}
	}
}
