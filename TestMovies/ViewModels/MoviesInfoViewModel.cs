using System;
using TestMovies.Models;
using TestMovies.Services;
using TestMovies.ViewModels.Base;

namespace TestMovies.ViewModels
{
    public class MoviesInfoViewModel : BaseViewModel
    {
        MovieModel _movieData;

        public MovieModel MovieData
        {
            get => _movieData;
            set
            {
                _movieData = value;
                OnPropertyChanged();
            }
        }

        public MoviesInfoViewModel(INavigator navigator) : base(navigator)
        {

        }
    }
}
