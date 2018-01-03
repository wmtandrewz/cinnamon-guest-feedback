
using Foundation;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using UIKit;

namespace CCFS.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			/*
             * Platform Specific Code for shift up page when keyboard onload
             * Source   :   Git Hub - Nuget Package
             * Link     :   https://github.com/paulpatarinski/Xamarin.Forms.Plugins/tree/master/KeyboardOverlap
             */
			KeyboardOverlapRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
