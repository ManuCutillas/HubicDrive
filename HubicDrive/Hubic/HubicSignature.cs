namespace HubicDrive.Hubic {
	public class HubicSignature {
		public string signature { get; private set; }
		public string maxFileSize { get; private set; }
		public string expires { get; private set; }


		public HubicSignature(string signature, string maxFileSize, string expires) {
			this.signature = signature;
			this.maxFileSize = maxFileSize;
			this.expires = expires;
		}
	}
}
