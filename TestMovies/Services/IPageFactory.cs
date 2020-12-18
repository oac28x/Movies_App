using System;
using Xamarin.Forms;

namespace TestMovies.Services
{
    public interface IPageFactory
    {
        void Register<TViewModel, TView>()
            where TViewModel : class, IBaseViewModel
            where TView : Page;

        Page Resolve<TViewModel>()
           where TViewModel : class, IBaseViewModel;
    }
}
