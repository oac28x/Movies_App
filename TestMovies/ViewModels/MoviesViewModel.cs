﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using TestMovies.DependencyServices;
using TestMovies.Models;
using TestMovies.Services;
using TestMovies.Utils;
using TestMovies.ViewModels.Base;
using Xamarin.Forms;

namespace TestMovies.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        int _pageCounter = 1;
        int _totalPages = 100;          //Set default value grater than _pageCounter
        bool _isMoviesLoading = false;
        bool _gointToNewPage = false;

        MovieModel[] _selectedItem = new MovieModel[2];
        private ObservableCollection<MovieModel> _moviesCollection = new ObservableCollection<MovieModel>();

        private readonly IApiHelperService _apiService;
        private readonly IViewModelFactory _viewModelService;
        private readonly IComponentContext _componentContext;

        public override bool IsPortrait
        {
            get => base.IsPortrait;
            set
            {
                base.IsPortrait = value;

                if (IsPortrait)
                {
                    CollectionColumns = Device.Idiom == TargetIdiom.Phone ? 2 : 3;
                }
                else
                {
                    CollectionColumns = 3;
                }
            }
        }

        public override bool IsReady
        {
            get => base.IsReady;
            set
            {
                base.IsReady = value;
                LoadMoreElementsAsync();
            }
        }

        public bool IsMoviesLoading
        {
            get => _isMoviesLoading;
            set
            {
                if (_pageCounter > 1)
                {
                    _isMoviesLoading = value;
                    OnPropertyChanged();
                }
                else
                {
                    IsLoading = value; 
                }

            }
        }

        private int collectionColumns = 2;
        public int CollectionColumns
        {
            get => collectionColumns;
            set
            {
                collectionColumns = value;
                OnPropertyChanged();
            }
        }

        
        public ObservableCollection<MovieModel> MoviesCollection
        {
            get => _moviesCollection;
            set
            {
                _moviesCollection = value;
                OnPropertyChanged();
            }
        }

        public MovieModel SelectedItem
        {
            get => _selectedItem[0];
            set
            {
                _selectedItem[1] = _selectedItem[0]; //Keep last item instead of using selectionChangeEvent
                _selectedItem[0] = value;

                OnPropertyChanged();

                if (_selectedItem[1] != null) _selectedItem[1].ItemSelected = false;
                if (_selectedItem[0] != null)
                {
                    _selectedItem[0].ItemSelected = true;
                    _viewModelService.Resolve<MoviesInfoViewModel>().MovieData = value;
                }
            }
        }

        public ICommand GoToMoviesInfoPage => new Command(() => GoToDetailsPage(), () => !_gointToNewPage && SelectedItem != null);
        public ICommand GoToSettingsPage => new Command(async () => await Navigator.PushAsync<SettingsViewModel>(), () => !_gointToNewPage);

        public ICommand LoadMoreMovies => new Command(() =>  LoadMoreElementsAsync(), () => _pageCounter > 1);
        public ICommand RateAppTapped => new Command(() => _componentContext.Resolve<IMessage>().ToastMessage("Thanks for rating us!"));

        public MoviesViewModel(
            IComponentContext componentContext,
            INavigator navigator,
            IViewModelFactory viewModelResolver,
            IApiHelperService apiHelper) : base(navigator)
        {
            _apiService = apiHelper;
            _viewModelService = viewModelResolver;
            _componentContext = componentContext;
        }

        async void GoToDetailsPage()
        {
            _gointToNewPage = true;

            await Task.Delay(TimeSpan.FromMilliseconds(150)); //Wait animation to go next page
            await Navigator.PushAsync<MoviesInfoViewModel>();

            _gointToNewPage = false;
        }

        async void LoadMoreElementsAsync()
        {
            if (IsLoading || IsMoviesLoading) return;

            IsMoviesLoading = true;

            await Task.Delay(TimeSpan.FromSeconds(1));
            var movies = await _apiService.GetPopularMovies("en", _pageCounter);

            MoviesCollection.AddRange(movies.Movies);

            IsMoviesLoading = false;

            _totalPages = movies.TotalPages;
            _pageCounter = movies.Page + 1;
        }
    }
}