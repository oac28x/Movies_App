using System;
using Android.Widget;
using TestMovies.DependencyServices;
using Xamarin.Forms;

//[assembly: Dependency(typeof(TestMovies.Droid.DependencyServices.MessagingAndroid))]  //Not required because of AutoFac
namespace TestMovies.Droid.DependencyServices
{
    public class MessagingAndroid : IMessage
    {
        public void ToastMessage(string message, bool longTime = false)
        {
            Toast.MakeText(MainActivity.ActivityContext, message, longTime ? ToastLength.Long : ToastLength.Short).Show();
        }
    }
}
