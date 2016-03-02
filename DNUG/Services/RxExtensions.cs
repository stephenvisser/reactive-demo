using System;
using Foundation;
using UIKit;
using System.Reactive.Linq;
using System.Reactive.Disposables;

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

	class TFDelegate: UITextFieldDelegate {

		private Action<string> callback;
		public TFDelegate(Action<string> callback) {
			this.callback = callback;
		}

		public override bool ShouldChangeCharacters (UITextField textField, NSRange range, string replacementString)
		{
			callback (textField.Text.Substring (0, (int) range.Location) + replacementString + textField.Text.Substring ((int) range.Location + (int) range.Length));
			return true;
		}
	}

	static class UITextFieldExtension {

		public static IObservable<string> Text(this UITextField field) {
			
			return Observable.Create<string>(observer => {
				field.Delegate = new TFDelegate(observer.OnNext);

				return Disposable.Empty;
			}).StartWith(field.Text);
		}
	}

	static class ObservableExtension {

		public static IObservable<T> Debug<T>(this IObservable<T> obs, string label) {
			return obs.Do (
				o => { 
					Console.WriteLine ("{0} Next: {1}", label, o);
				}, 
				e => {
					Console.WriteLine ("{0} Error: {1}", label, e);
				},
				() => {
					Console.WriteLine ("{0} Completed", label);
				}
			);	
		}
	}
}

