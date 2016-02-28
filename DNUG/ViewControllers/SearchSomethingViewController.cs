using Foundation;
using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

using UIKit;

namespace DNUG
{
	public partial class SearchSomethingViewController : UIViewController
	{
		private Search searcher = new Search();

		public SearchSomethingViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			searchField.Text ()
				.SelectMany (searcher.Perform)
				.Where(result => { return !string.IsNullOrEmpty(result); })
				.Subscribe (imageURL => {
					InvokeOnMainThread(() => {
						resultImageView.Image = new UIImage(NSData.FromUrl(new NSUrl(imageURL)));
					});
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


