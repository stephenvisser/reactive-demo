using Foundation;
using UIKit;

namespace DNUG
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			var navController = Window.RootViewController as UINavigationController;
				
			new Navigator ((vc, animated) => {
				navController.SetViewControllers (new UIViewController[] { vc }, animated);
			});

			return true;
		}
	}
}


