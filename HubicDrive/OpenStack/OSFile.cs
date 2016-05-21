namespace HubicDrive.OpenStack {
	public class OSFile : OSObject {
		public OSFolder Folder { get; set; } = null;


		public OSFile(string hash, string lastModified, string bytes, string name, string contentType) : base(hash, lastModified, bytes, name, contentType) {
		}
	}
}
