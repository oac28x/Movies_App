using System;
using System.Collections.Generic;
using Autofac;
using TestMovies.Services;
using Xamarin.Forms;

namespace TestMovies.Factories
{
    public class PageFactory : IPageFactory
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public PageFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Register<TViewModel, TView>()
            where TViewModel : class, IBaseViewModel
            where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Resolve<TViewModel>()
            where TViewModel : class, IBaseViewModel
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>();
            var viewType = _map[typeof(TViewModel)];
            var view = _componentContext.Resolve(viewType) as Page;

            view.BindingContext = viewModel;
            return view;
        }
    }
}
