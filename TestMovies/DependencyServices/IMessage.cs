using System;
namespace TestMovies.DependencyServices
{
    public interface IMessage
    {
        void ToastMessage(string message, bool longTime = false);
    }
}
