using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Foundation;
using UIKit;

namespace DNUG
{
	public partial class SearchSomethingViewController : UIViewController
	{
		private Search Searcher = new Search();
		public Subject<Unit> Back = new Subject<Unit> ();

		public SearchSomethingViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			searchField.Text ()
				.Throttle(TimeSpan.FromSeconds(1))
				.Select (t => { return Searcher.Perform(t).Catch(Observable.Empty<string>()); })
				.Switch()
				.Debug("Searching!")
				.Where(result => { return !string.IsNullOrEmpty(result); })
				.Subscribe (imageURL => {
					InvokeOnMainThread(() => {
						resultImageView.Image = new UIImage(NSData.FromUrl(new NSUrl(imageURL)));
					});
				});

			backButton.Tap ().Select(o => Unit.Default).Subscribe (Back);
		}
	}
}


