using System;
using Autofac;
using TestMovies.Services;

namespace TestMovies.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IComponentContext _componentContext;

        public ViewModelFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public TViewModel Resolve<TViewModel>()
            where TViewModel : class, IBaseViewModel
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>();
            return viewModel;
        }
    }
}
