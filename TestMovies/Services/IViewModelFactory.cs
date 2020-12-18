using System;
namespace TestMovies.Services
{
    public interface IViewModelFactory
    {
        TViewModel Resolve<TViewModel>()
            where TViewModel : class, IBaseViewModel;
    }
}
