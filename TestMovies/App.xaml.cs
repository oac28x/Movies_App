using System;
using System.Collections.Generic;
using Autofac;
using TestMovies.Bootsrapping;
using TestMovies.Pages;
using TestMovies.WebHelpers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace TestMovies
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; internal set; }
        public static int ScreenWidth { get; internal set; }

        public App()
        {
            InitializeComponent();
            //MainPage = new TestContentPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }


        public void SetScreenSizes(int height, int width)
        {
            ScreenHeight = height;
            ScreenWidth = width;
        }

        public void LoadTypes(Dictionary<Type, Type> mappedTypes)
        {
            Bootstrapper bootstrapper = new Bootstrapper(this);
            bootstrapper.Run(mappedTypes);
        }
    }
}
