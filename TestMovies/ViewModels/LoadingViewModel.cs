using System;
using TestMovies.Services;
using TestMovies.ViewModels.Base;

namespace TestMovies.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel(INavigator navigator) : base(navigator)
        {
        }
    }
}
