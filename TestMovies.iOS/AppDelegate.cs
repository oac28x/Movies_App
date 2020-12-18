using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using TestMovies.DependencyServices;
using TestMovies.iOS.DependencyServices;
using UIKit;

namespace TestMovies.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            Rg.Plugins.Popup.Popup.Init();
            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();

            global::Xamarin.Forms.Forms.Init();

            //Register DependecyServices AutoFac
            Dictionary<Type, Type> mapTypes = new Dictionary<Type, Type>();
            mapTypes.Add(typeof(IMessage), typeof(MessagingiOS));

            App application = new App();
            application.LoadTypes(mapTypes);
            application.SetScreenSizes((int)UIScreen.MainScreen.Bounds.Height, (int)UIScreen.MainScreen.Bounds.Width);

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }
    }
}
