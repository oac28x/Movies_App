using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using FFImageLoading.Forms.Platform;
using TestMovies.DependencyServices;
using TestMovies.Droid.DependencyServices;

namespace TestMovies.Droid
{
    [Activity(Label = "TestMovies", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static Context ActivityContext { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            ActivityContext = this;

            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);
            CachedImageRenderer.Init(enableFastRenderer: true);
            CachedImageRenderer.InitImageViewHandler();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Register DependecyServices AutoFac
            Dictionary<Type, Type> mapTypes = new Dictionary<Type, Type>();
            mapTypes.Add(typeof(IMessage), typeof(MessagingAndroid));

            App application = new App();
            application.LoadTypes(mapTypes);
            application.SetScreenSizes((int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density), (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density));

            LoadApplication(application);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}