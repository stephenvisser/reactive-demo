using System;
using Foundation;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using UIKit;

namespace DNUG
{
	public partial class TurnPhoneUpsideDownViewController : UIViewController
	{

		private Orientation orientation = new Orientation();

		public TurnPhoneUpsideDownViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			orientation.Stream.SubscribeOn (CurrentThreadScheduler.Instance).Subscribe (orientation => {
				switch(orientation) {
				case OrientationValue.Down:
					OrientationLabel.Text = "Down";
					break;
				case OrientationValue.Up:
					OrientationLabel.Text = "Up";
					break;
				case OrientationValue.Sideways:
					OrientationLabel.Text = "Sideways";
					break;
				}
			});
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


