using System;
using Foundation;
using UIKit;
using System.Reactive.Linq;

namespace DNUG
{
	static class UIButtonRxExtension {
		public static IObservable<object> Tap(this UIButton button) {
			return Observable.FromEventPattern( ev => button.TouchUpInside += ev, ev => button.TouchUpInside -= ev);
		}
	}

	static class UIStoryboardExtension {
		public static T Instantiate<T>(this UIStoryboard storyboard) where T: UIViewController {
			return storyboard.InstantiateViewController(typeof(T).Name) as T;
		}
	}

}

