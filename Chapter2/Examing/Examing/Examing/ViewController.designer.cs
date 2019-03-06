// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;


namespace Examing
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField num1 { get; set; }

		[Outlet]
		AppKit.NSTextField num2 { get; set; }

		[Outlet]
		AppKit.NSTextField outcome { get; set; }

		[Outlet]
		AppKit.NSTextField userAnswer { get; set; }

		[Action ("submit:")]
		partial void submit (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (num1 != null) {
				num1.Dispose ();
				num1 = null;
			}

			if (num2 != null) {
				num2.Dispose ();
				num2 = null;
			}

			if (userAnswer != null) {
				userAnswer.Dispose ();
				userAnswer = null;
			}

			if (outcome != null) {
				outcome.Dispose ();
				outcome = null;
			}
		}
	}
}
