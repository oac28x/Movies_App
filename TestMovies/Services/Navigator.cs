using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace TestMovies.Services
{
    public class Navigator : INavigator
    {
        private readonly Lazy<INavigation> _navigation;
        private readonly IPageFactory _pageFactory;

        public Navigator(Lazy<INavigation> navigation, IPageFactory pageFactory)
        {
            _navigation = navigation;
            _pageFactory = pageFactory;
        }

        public INavigation Navigation { get => _navigation.Value; }

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel
        {
            var page = _pageFactory.Resolve<TViewModel>();
            await Navigation.PushAsync(page);
        }

        public async Task PushModalAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel
        {
            var page = _pageFactory.Resolve<TViewModel>();
            await Navigation.PushModalAsync(page);
        }


        /// <summary>
        /// Used to push PopUpPages
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public async Task PushPopupAsync<TViewModel>()
            where TViewModel : class, IBaseViewModel
        {
            var page = (PopupPage)_pageFactory.Resolve<TViewModel>();
            await Navigation.PushPopupAsync(page);
        }

        /// <summary>
        /// Used to Pop last PopupPage
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public async Task PopPopupAsync()
        {
            await Navigation.PopPopupAsync(); ;
        }

        /// <summary>
        /// Used to Pop all PopupPages
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public async Task PopAllPopupAsync()
        {
            await Navigation.PopAllPopupAsync(); ;
        }
    }
}
