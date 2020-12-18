using System;
using Autofac;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using TestMovies.Factories;
using TestMovies.Services;
using TestMovies.Utils;
using Xamarin.Forms;

namespace TestMovies.Bootsrapping.Modules
{
    public class AutofactModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PageFactory>().As<IPageFactory>().SingleInstance();

            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>().SingleInstance();

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.RegisterType<LocalStorageProperties>().As<IPropertiesService>().SingleInstance();

            builder.Register<INavigation>(context => App.Current.MainPage.Navigation).SingleInstance();  //Get lazy Xamarin Navigation Service

            builder.Register<ISettings>(context => CrossSettings.Current).SingleInstance();  //Properties plugin
        }
    }
}
