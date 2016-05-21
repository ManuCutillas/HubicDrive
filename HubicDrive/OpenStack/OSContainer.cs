using System;

namespace HubicDrive.OpenStack {
	public class OSContainer {
		public string Count { get; }

		public long Bytes { get; } = 0;

		public string Name { get; }

		public string Size {
			get {
				return Helper.HumanReadableSize(this.Bytes);
			}
		}


		public OSContainer(string count, string bytes, string name) {
			this.Count = count;
			this.Bytes = Convert.ToInt64(bytes);
			this.Name = name;
		}
	}
}