using System;
using Autofac;
using TestMovies.Services;
using TestMovies.Utils;
using TestMovies.WebHelpers;

namespace TestMovies.Bootsrapping.Modules
{
    public class HelpersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiHelper>().As<IApiHelperService>().SingleInstance();

            builder.RegisterType<WeakEventHandler>().As<IWeakReferenceService>(); //.SingleInstance();

        }
    }
}
