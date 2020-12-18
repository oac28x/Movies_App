using System;
using System.Threading.Tasks;

namespace TestMovies.Services
{
    public interface INavigator
    {
        Task PopAsync();

        Task PopToRootAsync();

        Task PushAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel;

        Task PushModalAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel;



        Task PushPopupAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel;

        Task PopPopupAsync();

        Task PopAllPopupAsync();
    }
}
