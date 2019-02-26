// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwoProduct
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField a { get; set; }

        [Outlet]
        AppKit.NSTextField b { get; set; }

        [Outlet]
        AppKit.NSTextField result { get; set; }

        [Action ("calculate:")]
        partial void calculate (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (result != null) {
                result.Dispose ();
                result = null;
            }

            if (a != null) {
                a.Dispose ();
                a = null;
            }

            if (b != null) {
                b.Dispose ();
                b = null;
            }
        }
    }
}
