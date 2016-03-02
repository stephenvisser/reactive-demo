using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UIKit;

namespace DNUG
{
	public partial class GoHomeViewController : UIViewController
	{
		public Subject<Unit> AcceptFate = new Subject<Unit>();

		public GoHomeViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			accept
				.Tap ()
				.Select<object, Unit> (val => { throw new ArgumentException (); })
				.Subscribe(AcceptFate);
		}
	}
}


