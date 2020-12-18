using System;
using Xamarin.Forms;

namespace TestMovies.CustomViews
{
    public class CustomParallax : Grid
    {
        private CollectionView _collectionViewToScroll;
        private ScrollView _scrollViewToScroll;


        //Did not binded property it is just assigned on instance creation
        public int ParallaxSpeed { get; set; } = 5;     //Bigger -> slower

        private double _headinHeight = 0;
        public double HeadingHeight
        {
            private get => _headinHeight;
            set
            {
                _headinHeight = value;
                if (_collectionViewToScroll != null) _collectionViewToScroll.Margin = new Thickness(0, _headinHeight, 0, 0);
                if (_scrollViewToScroll != null) _scrollViewToScroll.Margin = new Thickness(0, _headinHeight, 0, 0);
            }
        }

        public VisualElement ParallaxHeading { get; set; }

        public CollectionView CollectionViewToScroll
        {
            set
            {
                _collectionViewToScroll = value;
                _collectionViewToScroll.Scrolled += CollectionView_Scrolled; //Weak handler is required
            }
        }

        public ScrollView ScrollViewToScroll
        {
            set
            {
                _scrollViewToScroll = value;
                _scrollViewToScroll.Scrolled += ScrollView_Scrolled;  //Weak handler is required
            }
        }

        public CustomParallax()
        {

        }


        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            MathParallax(e.ScrollY, _scrollViewToScroll);
        }

        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            MathParallax(e.VerticalOffset, _collectionViewToScroll);
        }


        double lastScrolled = 0;
        double lastRowHeight = 0;

        private void MathParallax(double scrolledValue, View scroll)
        {
            if (HeadingHeight < 0 || lastScrolled == scrolledValue) return;

            double rowHeight;

            if (scrolledValue == 0)
            {
                rowHeight = 0;
                if (lastRowHeight == rowHeight) return;
            }
            else
            {
                double div = scrolledValue / ParallaxSpeed;

                rowHeight = -div;

                if (div >= HeadingHeight) rowHeight = -HeadingHeight;

                if (lastRowHeight == rowHeight) return;
            }

            lastRowHeight = rowHeight;
            lastScrolled = scrolledValue;

            scroll.Margin = new Thickness(0, rowHeight + HeadingHeight, 0, 0);
            ParallaxHeading.TranslationY = rowHeight;
        }



        //private void MathParallax(double scrolledValue)
        //{
        //    if (HeadingHeight < 0) return;

        //    double rowHeight;

        //    if (scrolledValue == 0)
        //    {
        //        rowHeight = HeadingHeight;
        //    }
        //    else
        //    {
        //        double div = scrolledValue / ParallaxSpeed;
        //        rowHeight = HeadingHeight - div;
        //        if (rowHeight < 0) rowHeight = 0;
        //    }

        //    GridRow.Height = rowHeight;
        //}
    }
}
