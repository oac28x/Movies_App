using System;
using Autofac;
using TestMovies.Pages;
using TestMovies.Pages.PopUpPages;
using TestMovies.Services;
using TestMovies.ViewModels;

namespace TestMovies.Bootsrapping.Modules
{
    public class MoviesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Movies Page
            builder.RegisterType<MoviesContentPage>().SingleInstance();
            builder.RegisterType<MoviesViewModel>().SingleInstance();

            //Movies Info Page
            builder.RegisterType<MoviesInfoContentPage>().SingleInstance();
            builder.RegisterType<MoviesInfoViewModel>().SingleInstance();

            //Settings Page
            builder.RegisterType<SettingsContentPage>().SingleInstance();
            builder.RegisterType<SettingsViewModel>().SingleInstance();

            //PopUpPage BusyIndicator
            builder.RegisterType<LoadingPopUpPage>().SingleInstance();
            builder.RegisterType<LoadingViewModel>().SingleInstance();
        }
    }
}
