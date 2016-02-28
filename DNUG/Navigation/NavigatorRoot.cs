using System;
using Foundation;
using UIKit;
using System.Reactive.Linq;

namespace DNUG
{
	public abstract class NavigatorRoot
	{
		private UIStoryboard storyboard = UIStoryboard.FromName("Main", NSBundle.MainBundle);
		private Action<UIViewController, bool> Navigate { get; set; }

		protected Func<Param, IObservable<ReturnValue>> Show<View, Param, ReturnValue>(Func<View, Param, IObservable<ReturnValue>> setup, bool animate = true) where View: UIViewController {
			return param => {
				var vc = storyboard.Instantiate<View> ();
				Navigate (vc, animate);
				return setup(vc, param);
			};
		}
			
		protected Func<IObservable<ReturnValue>> Show<View, ReturnValue>(Func<View, IObservable<ReturnValue>> setup, bool animate = true) where View: UIViewController {
			return () => {
				var vc = storyboard.Instantiate<View> ();
				Navigate (vc, animate);
				return setup(vc);
			};
		}

		protected NavigatorRoot (Action<UIViewController, bool> navigate)
		{
			this.Navigate = navigate;
		}
	}
}

