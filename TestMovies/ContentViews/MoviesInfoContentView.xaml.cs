using System;
using System.Collections.Generic;
using TestMovies.CustomViews;
using Xamarin.Forms;

namespace TestMovies.ContentViews
{
    public partial class MoviesInfoContentView : ContentView
    {
        public CustomParallax ParallaxLayout => parallaxLayout;
        public VisualElement ParallaxHeading => parallaxHeading;

        public MoviesInfoContentView()
        {
            InitializeComponent();
        }
    }
}
