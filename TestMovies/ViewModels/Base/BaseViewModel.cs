using TestMovies.Services;

namespace TestMovies.ViewModels.Base
{
    public class BaseViewModel : Observable, IBaseViewModel
    {
        bool _isLoading = false;
        bool _isLandscape = true;
        bool _isReady = false;
        string _lang = "en";

        public INavigator Navigator { get; set; }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;

                if (IsReady) { 
                    if (_isLoading)
                    {
                        Navigator.PushPopupAsync<LoadingViewModel>();
                    }
                    else
                    {
                        Navigator.PopAllPopupAsync();
                    }
                }

                OnPropertyChanged();
            }
        }

        virtual public bool IsLandscape
        {
            get { return _isLandscape; }
            set
            {
                _isLandscape = value;
                OnPropertyChanged();
            }
        }

        virtual public bool IsReady
        {
            get => _isReady;
            set
            {
                _isReady = value;
                OnPropertyChanged();
            }
        }

        virtual public string Languague
        {
            get => _lang;
            set
            {
                _lang = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel(INavigator navigator)
        {
            Navigator = navigator;
        }
    }
}
