using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using TestMovies.Services;
using Xamarin.Forms;

namespace TestMovies.Pages.PopUpPages
{
    public partial class LoadingPopUpPage : PopupPage
    {
        IBaseViewModel _viewModel;
        public LoadingPopUpPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.IsLoading = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.IsLoading = false;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _viewModel = BindingContext as IBaseViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}
