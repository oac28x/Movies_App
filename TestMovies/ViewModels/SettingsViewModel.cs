using System;
using System.Globalization;
using TestMovies.Services;
using TestMovies.ViewModels.Base;

namespace TestMovies.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IPropertiesService _settings;

        private readonly string[] _langguages = { "en", "es" };


        private string _appLanguage = "en"; //Set default



        public string AppLanguage
        {
            get => _appLanguage;
            set
            {
                _appLanguage = value;
                _settings.AddOrUpdateValue("_appLang", _appLanguage);
            }
        }

        public CultureInfo AppCultureInfo { get; set; }
        

        public SettingsViewModel(INavigator navigator, IPropertiesService settings) : base(navigator)
        {
            _settings = settings;
        }
    }
}
