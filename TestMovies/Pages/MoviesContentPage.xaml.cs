using TestMovies.ViewModels;
using Xamarin.Forms;

namespace TestMovies.Pages
{
    public partial class MoviesContentPage : ContentPage
    {
        private double width;
        private double height;

        private MoviesViewModel _viewModel;

        public MoviesContentPage()
        {
            InitializeComponent();

            parallaxHeading.SizeChanged += ParallaxHeading_SizeChanged;
        }

        private void ParallaxHeading_SizeChanged(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("HeightRequest" + parallaxHeading.Height);

            parallaxLayout.HeadingHeight = parallaxHeading.Height;
            parallaxHeading.SizeChanged -= ParallaxHeading_SizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            moviesCollectionView.SelectedItem = null;
            if (!_viewModel.IsReady) _viewModel.IsReady = true;
            //parallaxLayout.HeadingHeight = parallaxHeading.HeightRequest;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _viewModel = BindingContext as MoviesViewModel;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    _viewModel.IsLandscape = true;
                    moviesCollectionView.SelectedItem = null;
                    contentMovieInfo.ParallaxLayout.HeadingHeight = contentMovieInfo.ParallaxHeading.Height;
                }
                else
                {
                    _viewModel.IsLandscape = false; 
                }
            }
        }
    }
}
