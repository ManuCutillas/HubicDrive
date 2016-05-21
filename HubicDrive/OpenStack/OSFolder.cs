using System.Collections.Generic;

namespace HubicDrive.OpenStack {
	public class OSFolder : OSObject {
		public bool Loaded { get; set; } = false;
		public Dictionary<string, OSFolder> Subfolders { get; set; } = null;
		public Dictionary<string, OSFile> Files { get; set; } = null;


		public OSFolder(string hash, string lastModified, string bytes, string path, string contentType) : base(hash, lastModified, bytes, path, contentType) {
		}
	}
}
