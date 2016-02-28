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
	[Register ("TurnPhoneUpsideDownViewController")]
	partial class TurnPhoneUpsideDownViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel OrientationLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (OrientationLabel != null) {
				OrientationLabel.Dispose ();
				OrientationLabel = null;
			}
		}
	}
}
