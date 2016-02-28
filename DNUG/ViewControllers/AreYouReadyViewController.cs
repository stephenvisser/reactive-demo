using System;

using UIKit;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DNUG
{
	public partial class AreYouReadyViewController : UIViewController
	{

		public Subject<bool> UserResponse = new Subject<bool>();

		public AreYouReadyViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var yes = yesButton.Tap ().Select (o => true);
			var no = noButton.Tap ().Select(o=> false);

			yes
				.Merge (no)
				.Subscribe (UserResponse);
				
		}
	}
}

