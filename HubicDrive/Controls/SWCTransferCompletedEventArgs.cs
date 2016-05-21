using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubicDrive.Controls {
	public class SWCTransferCompletedEventArgs : EventArgs {
		public bool Cancelled { get; private set; } = false;
		public string Error { get; private set; } = null;
	}
}
