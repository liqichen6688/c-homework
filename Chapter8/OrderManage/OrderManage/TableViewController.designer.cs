// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace OrderManage
{
    [Register ("TableViewController")]
    partial class TableViewController
    {
        [Outlet]
        AppKit.NSTextField IDText { get; set; }

        [Outlet]
        AppKit.NSTextField NameText { get; set; }

        [Outlet]
        AppKit.NSClipView Table { get; set; }

        [Outlet]
        AppKit.NSScrollView Table1 { get; set; }

        [Outlet]
        AppKit.NSTextField ValueText { get; set; }

        [Action ("AddNew:")]
        partial void AddNew (Foundation.NSObject sender);

        [Action ("AddNewButton:")]
        partial void AddNewButton (Foundation.NSObject sender);

        [Action ("deleteButn:")]
        partial void deleteButn (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (IDText != null) {
                IDText.Dispose ();
                IDText = null;
            }

            if (NameText != null) {
                NameText.Dispose ();
                NameText = null;
            }

            if (Table != null) {
                Table.Dispose ();
                Table = null;
            }

            if (ValueText != null) {
                ValueText.Dispose ();
                ValueText = null;
            }

            if (Table1 != null) {
                Table1.Dispose ();
                Table1 = null;
            }
        }
    }
}
