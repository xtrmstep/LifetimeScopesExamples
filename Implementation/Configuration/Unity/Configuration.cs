using System.Reflection;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using LifetimeScopesExamples.Implementation.Repositories.Properties;
using Microsoft.Practices.Unity;

namespace LifetimeScopesExamples.Implementation.Configuration.Unity
{
    public class Configuration : IConfiguration
    {
        public IDependencyResolver Constructors()
        {
            var container = new UnityContainer();
            container.RegisterType<IAuthorRepository, AuthorRepositoryCtro>();
            container.RegisterType<IBookRepository, BookRepositoryCtro>();
            container.RegisterType<ILog, ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Expressions()
        {
            var container = new UnityContainer();
            container.RegisterType<IAuthorRepository>(new InjectionFactory(c => new AuthorRepositoryCtro(c.Resolve<ILog>(), c.Resolve<IBookRepository>())));
            container.RegisterType<IBookRepository>(new InjectionFactory(c => new BookRepositoryCtro(c.Resolve<ILog>())));
            container.RegisterType<ILog>(new InjectionFactory(c => new ConsoleLog()));

            return new DependencyResolver(container);
        }

        public IDependencyResolver Properties()
        {
            var container = new UnityContainer();
            container.RegisterType<IAuthorRepository, AuthorRepositoryProp>();
            container.RegisterType<IBookRepository, BookRepositoryProp>();
            container.RegisterType<ILog, ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Methods()
        {
            var container = new UnityContainer();
            container.RegisterType<IAuthorRepository, AuthorRepositoryMtd>();
            container.RegisterType<IBookRepository, BookRepositoryMtd>();
            container.RegisterType<ILog, ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Auto()
        {
            var container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssemblies(Assembly.GetExecutingAssembly()),
                WithMappings.FromAllInterfaces);
            return new DependencyResolver(container);
        }

        public IDependencyResolver Module()
        {
            var container = new UnityContainer();
            container.AddNewExtension<ImplementationModule>();
            return new DependencyResolver(container);
        }

        private class DependencyResolver : IDependencyResolver
        {
            private readonly UnityContainer _container;

            public DependencyResolver(UnityContainer container)
            {
                _container = container;
            }

            public T Resolve<T>() where T : class
            {
                return _container.Resolve<T>();
            }
        }
    }
}