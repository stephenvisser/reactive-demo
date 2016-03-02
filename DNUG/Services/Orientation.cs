using System;
using Foundation;
using CoreMotion;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace DNUG
{
	public enum OrientationValue {
		Up,
		Down,
		Sideways
	}

	public class Orientation
	{
		public IObservable<OrientationValue> Stream;

		public Orientation ()
		{
			Stream = Observable.Create<OrientationValue>(observer => {
				var manager = new CMMotionManager ();

				manager.AccelerometerUpdateInterval = 0.1;

				manager.StartAccelerometerUpdates(NSOperationQueue.MainQueue, (data, error) => {
					if (error == null) {

						if (data.Acceleration.Y > 0.5) {
							observer.OnNext(OrientationValue.Down);
						} else if (data.Acceleration.Y < -0.5) {
							observer.OnNext(OrientationValue.Up);
						} else {
							observer.OnNext(OrientationValue.Sideways);
						}
					}
				});

				return Disposable.Create(() => {
					manager.StopAccelerometerUpdates();
				});
			});
		}
	}
}

