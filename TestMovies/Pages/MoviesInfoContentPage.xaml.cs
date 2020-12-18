using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestMovies.Pages
{
    public partial class MoviesInfoContentPage : ContentPage
    {
        public MoviesInfoContentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            contentMovieInfo.ParallaxLayout.HeadingHeight = contentMovieInfo.ParallaxHeading.Height;
        }
    }
}
