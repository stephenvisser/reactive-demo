using System;
using Foundation;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Collections.Generic;

namespace DNUG
{
	public class Search
	{
		private NSUrlSession session = NSUrlSession.SharedSession;
		public Search ()
		{
		}

		public IObservable<string> Perform(String term) {

			var request = new NSUrlRequest (new NSUrl (String.Format("https://api.duckduckgo.com/?q={0}&format=json&pretty=1", term.Replace(' ', '+'))));

			return Observable.Create<string> (observable => {
				var network = session.CreateDataTask (request, (data, response, error) => {

					var result = NSJsonSerialization.Deserialize(data, 0, out error) as NSDictionary;
					if (result != null) {
						var imageURL = (result["Image"] as NSString).ToString();
						if (string.IsNullOrEmpty(imageURL)) {
							observable.OnNext(null);
						} else {
							observable.OnNext(imageURL);
						}
					} else {
						observable.OnNext(null);
					}
				});

				network.Resume();

				return Disposable.Create(network.Cancel);
			});

			
		}
	}
}

