using System;
using Autofac;
using TestMovies.Bootsrapping.Modules;
using TestMovies.Pages;
using TestMovies.Pages.PopUpPages;
using TestMovies.Services;
using TestMovies.ViewModels;
using Xamarin.Forms;

namespace TestMovies.Bootsrapping
{
    public class Bootstrapper : AutofactBootsrapper
    {
        private App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            //Register extra modules
            builder.RegisterModule<MoviesModule>();
            builder.RegisterModule<HelpersModule>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            IPageFactory pageFactory = container.Resolve<IPageFactory>();

            Page moviesPage = pageFactory.Resolve<MoviesViewModel>();

            _app.MainPage = new NavigationPage(moviesPage);
        }

        protected override void RegisterViews(IPageFactory pageFactory)
        {
            //Register ViewModel with respective ViewModel
            pageFactory.Register<MoviesViewModel, MoviesContentPage>();
            pageFactory.Register<MoviesInfoViewModel, MoviesInfoContentPage>();
            pageFactory.Register<SettingsViewModel, SettingsContentPage>();

            //PopUpPage
            pageFactory.Register<LoadingViewModel, LoadingPopUpPage>();
        }
    }
}
