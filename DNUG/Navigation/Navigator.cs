using System;
using System.Reactive;
using System.Reactive.Linq;

using UIKit;

namespace DNUG
{
	public class Navigator: NavigatorRoot
	{
		public Navigator (Action<UIViewController, bool> navigate): base(navigate)
		{
			Observable.Defer(() => { return Show<AreYouReadyViewController, bool>(vc => vc.UserResponse, false)(); })
				.SelectMany(result => {
					if (result) {
						return Observable.Empty<Unit>();
					} else {
						return Show<GoHomeViewController, Unit>(vc => vc.AcceptFate)();
					}
				})
				.Retry()
				.Subscribe(result => Console.WriteLine("{0}", result));
		}
	}
}

