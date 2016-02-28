using System;
using System.Reactive;
using UIKit;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DNUG
{
	public partial class GoHomeViewController : UIViewController
	{
		public Subject<Unit> AcceptFate = new Subject<Unit>();

		public GoHomeViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			accept
				.Tap ()
				.Select ((val) => {
					throw new ArgumentException ();
					return Unit.Default;
				})
				.Subscribe(AcceptFate);
		}
	}
}


