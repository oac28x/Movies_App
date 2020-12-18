using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using TestMovies.Bootsrapping.Modules;
using TestMovies.Services;

namespace TestMovies.Bootsrapping
{
    public abstract class AutofactBootsrapper
    {
        private Dictionary<Type, Type> _mappedTypes;

        public void Run(Dictionary<Type, Type> mappedTypes)
        {
            _mappedTypes = mappedTypes;

            ContainerBuilder builder = new ContainerBuilder();
            
            ConfigureContainer(builder);

            IContainer container = builder.Build();

            IPageFactory pageFactory = container.Resolve<IPageFactory>();
            RegisterViews(pageFactory);
            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            if(_mappedTypes != null && _mappedTypes.Any())
            {
                builder.RegisterModule(new MappedTypeModule(_mappedTypes));
            }

            builder.RegisterModule<AutofactModule>();
        }

        protected abstract void RegisterViews(IPageFactory pageFactory);

        protected abstract void ConfigureApplication(IContainer container);
    }
}
