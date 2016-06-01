using System;

namespace HubicDrive {
	class Helper {
		public static string HumanReadableSize(long byteCount) {
			string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

			if (byteCount == 0)
				return "0 " + suf[0];

			long bytes = Math.Abs(byteCount);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);

			return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
		}


		public static string HumanReadableTime(TimeSpan timeSpan) {
			if (timeSpan == TimeSpan.Zero)
				return "0";

			if (timeSpan.Days > 0)
				return timeSpan.Days + " days";

			return timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds;
		}
	}
}
