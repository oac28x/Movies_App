using System;
using System.Collections.Generic;
using Autofac;

namespace TestMovies.Bootsrapping.Modules
{
    public class MappedTypeModule : Module
    {
        private Dictionary<Type, Type> _mappedTypes;

        public MappedTypeModule(Dictionary<Type, Type> mappedTypes)
        {
            _mappedTypes = mappedTypes;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var item in _mappedTypes)
            {
                builder.RegisterType(item.Value).As(item.Key);
            }
        }
    }
}
