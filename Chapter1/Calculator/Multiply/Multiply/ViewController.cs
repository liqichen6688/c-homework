using System;

using AppKit;
using Foundation;

namespace Multiply
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        partial void calculate(NSObject sender)
        {
            result.StringValue = Convert.ToString(Convert.ToDouble(a.StringValue)* Convert.ToDouble(b.StringValue));
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            result.StringValue = "None";


            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
