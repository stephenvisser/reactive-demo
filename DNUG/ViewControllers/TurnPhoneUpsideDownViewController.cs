using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Foundation;
using UIKit;

namespace DNUG
{
	public partial class TurnPhoneUpsideDownViewController : UIViewController
	{
		private Orientation orientation = new Orientation();
		private CompositeDisposable disp = new CompositeDisposable();
		public Subject<Unit> UpsideDown = new Subject<Unit>();

		public TurnPhoneUpsideDownViewController (IntPtr handle) : base (handle) { }

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

			var publishEventsDisp = orientation.Stream
				.Where (orientation => orientation == OrientationValue.Down)
				.Select (orientation => Unit.Default)
				.Subscribe(UpsideDown);

			disp.Add (publishEventsDisp);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			disp.Dispose ();
		}
	}
}


