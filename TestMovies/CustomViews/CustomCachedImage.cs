using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace TestMovies.CustomViews
{
    public class CustomCachedImage : CachedImage
    {
        public static readonly BindableProperty AnimateProperty = BindableProperty.Create("Animate", typeof(bool), typeof(CustomCachedImage), false, propertyChanged: AnimateChanged);

        private const uint CACHING_DAYS = 10;
        private const uint ANIMATION_TIME_MS = 150;

        public bool Animate
        {
            get { return (bool)GetValue(AnimateProperty); }
            set { SetValue(AnimateProperty, value); }
        }

        public CustomCachedImage()
        {
            //Default config
            this.CacheType = FFImageLoading.Cache.CacheType.Disk;
            this.CacheDuration = TimeSpan.FromDays(CACHING_DAYS);
            this.RetryCount = 2;
            this.RetryDelay = 200;
            this.FadeAnimationEnabled = false;
        }

        private static void AnimateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool isOpen;

            if (bindable != null && newValue != null)
            {
                var control = (CustomCachedImage)bindable;
                isOpen = (bool)newValue;

                if (control.Animate)
                {
                    control.AnimateBig();
                }
                else
                {
                    control.AnimateOriginal();
                }
            }
        }


        async void AnimateBig()
        {
            await this.ScaleTo(1.1, ANIMATION_TIME_MS);
        }

        async void AnimateOriginal()
        {
            await this.ScaleTo(1, ANIMATION_TIME_MS);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            HeightRequest = this.Width * 1.5;  //Aspect ratio

            //Force Reload on device orientation
            ImageSource imgSource = this.Source;
            this.Source = null;
            this.Source = imgSource;
        }  
    }
}
