using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubicDrive.Controls {
	public class SWCTransferProgressChangedEventArgs : EventArgs {
		public long BytesTransfered { get; } = 0;
		public int ProgressPercentage { get; }
		public long TotalBytesToTransfer { get; } = 0;

		public SWCTransferProgressChangedEventArgs(long bytesTransfered, long totalBytesToTransfer) {
			this.BytesTransfered = bytesTransfered;
			this.TotalBytesToTransfer = totalBytesToTransfer;

			this.ProgressPercentage = (Int32) (this.BytesTransfered * 100 / this.TotalBytesToTransfer);
		}
	}
}
