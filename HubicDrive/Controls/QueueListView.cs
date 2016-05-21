using System.Windows.Forms;

namespace HubicDrive.Controls {
	public partial class QueueListView : ListView {
		public QueueListView() {
			InitializeComponent();
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.EnableNotifyMessage, true);
		}


		protected override void OnNotifyMessage(Message m) {
			if (m.Msg != 0x14)
				base.OnNotifyMessage(m);
		}
	}
}
