using GlobalToast;
using TestMovies.DependencyServices;

//[assembly: Dependency(typeof(TestMovies.iOS.DependencyServices.MessagingiOS))]  //Not required because of AutoFac
namespace TestMovies.iOS.DependencyServices
{
    public class MessagingiOS : IMessage
    {
        public void ToastMessage(string message, bool longTime = false)
        {
            Toast.MakeToast(message)
            .SetPosition(ToastPosition.Bottom)
            .SetDuration( longTime ? ToastDuration.Long : ToastDuration.Regular)
            .SetShowShadow(false) 
            .Show();
        }
    }
}
