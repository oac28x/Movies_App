using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestMovies.CustomViews
{
    public partial class CustomSnackBar : TemplatedView
    {
        public static readonly BindableProperty MessageProperty = BindableProperty.Create("Message", typeof(string), typeof(CustomSnackBar), default(string));
        public static readonly BindableProperty IsOpenProperty = BindableProperty.Create("IsOpen", typeof(bool), typeof(CustomSnackBar), false, propertyChanged: IsOpenChanged);

        private const uint ANIMATION_TIME_MS = 150;

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set
            {
                SetValue(MessageProperty, value);
                OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public CustomSnackBar()
        {
            InitializeComponent();
        }

        async void Close()
        {
            await this.TranslateTo(0, 41, ANIMATION_TIME_MS);
            //IsOpen = IsVisible = false;
        }

        async void Open()
        {
            //IsVisible = true;
            await this.TranslateTo(0, 1, ANIMATION_TIME_MS);
        }

        private static void IsOpenChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool isOpen;

            if (bindable != null && newValue != null)
            {
                var control = (CustomSnackBar)bindable;
                isOpen = (bool)newValue;

                if (!control.IsOpen)
                {
                    control.Close();
                }
                else
                {
                    control.Open();
                }
            }
        }
    }
}
