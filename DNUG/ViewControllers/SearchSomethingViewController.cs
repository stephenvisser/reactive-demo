using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Foundation;
using UIKit;

namespace DNUG
{
	public partial class SearchSomethingViewController : UIViewController
	{
		private Search searcher = new Search();

		public SearchSomethingViewController (IntPtr handle) : base (handle) { }

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
		}
	}
}


