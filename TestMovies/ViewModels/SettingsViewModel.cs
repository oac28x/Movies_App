using System;
using TestMovies.Services;
using TestMovies.ViewModels.Base;

namespace TestMovies.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IPropertiesService _settings;

        public SettingsViewModel(INavigator navigator, IPropertiesService settings) : base(navigator)
        {
            _settings = settings;
        }
    }
}
