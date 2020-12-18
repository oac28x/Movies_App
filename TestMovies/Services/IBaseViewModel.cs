using System;
using System.ComponentModel;

namespace TestMovies.Services
{
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        INavigator Navigator { get; set; }

        bool IsLoading { get; set; }
    }
}
