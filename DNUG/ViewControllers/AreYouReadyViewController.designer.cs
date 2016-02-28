// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DNUG
{
	[Register ("AreYouReadyViewController")]
	partial class AreYouReadyViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton noButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton yesButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (noButton != null) {
				noButton.Dispose ();
				noButton = null;
			}
			if (yesButton != null) {
				yesButton.Dispose ();
				yesButton = null;
			}
		}
	}
}
