using Autofac;
using LifetimeScopesExamples.Abstraction;

namespace LifetimeScopesExamples.Configuration.Autofac
{
    public static class Configuration
    {
        public static IDependencyResolver Setup()
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();
            return new DependencyResolver(container);
        }

        private class DependencyResolver : IDependencyResolver
        {
            private readonly IContainer _container;

            public DependencyResolver(IContainer container)
            {
                _container = container;
            }

            public T Resolve<T>()
            {
                return _container.Resolve<T>();
            }
        }
    }
}