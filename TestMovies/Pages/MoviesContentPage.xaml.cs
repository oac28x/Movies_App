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
                    _viewModel.IsPortrait = false;
                }
                else
                {
                    _viewModel.IsPortrait = true;

                    //innerGrid.RowDefinitions.Clear();
                    //innerGrid.ColumnDefinitions.Clear();
                    //innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    //innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    //innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    //innerGrid.Children.Remove(controlsGrid);
                    //innerGrid.Children.Add(controlsGrid, 1, 0);

                    //innerGrid.RowDefinitions.Clear();
                    //innerGrid.ColumnDefinitions.Clear();
                    //innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    //innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    //innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    //innerGrid.Children.Remove(controlsGrid);
                    //innerGrid.Children.Add(controlsGrid, 0, 1);
                }
            }
        }
    }
}
