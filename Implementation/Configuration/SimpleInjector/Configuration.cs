using System;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using LifetimeScopesExamples.Implementation.Repositories.Properties;
using SimpleInjector;

namespace LifetimeScopesExamples.Implementation.Configuration.SimpleInjector
{
    public static class Configuration
    {
        public static IDependencyResolver Simple()
        {
            var container = new Container();

            container.Register<IAuthorRepository, AuthorRepositoryCtro>();
            container.Register<IBookRepository, BookRepositoryCtro>();
            container.Register<ILog, ConsoleLog>();

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Expressions()
        {
            var container = new Container();
            container.Register<IAuthorRepository>(() => new AuthorRepositoryCtro(container.GetInstance<ILog>(), container.GetInstance<IBookRepository>()));
            container.Register<IBookRepository>(() => new BookRepositoryCtro(container.GetInstance<ILog>()));
            container.Register<ILog>(() => new ConsoleLog());
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Properties()
        {
            var container = new Container();
            container.Register<IAuthorRepository>(() => new AuthorRepositoryProp {Log = container.GetInstance<ILog>(), BookRepository = container.GetInstance<IBookRepository>()});
            container.Register<IBookRepository>(() => new BookRepositoryProp {Log = container.GetInstance<ILog>()});
            container.Register<ILog>(() => new ConsoleLog());
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Methods()
        {
            var container = new Container();
            container.Register<IAuthorRepository>(() =>
            {
                var rep = new AuthorRepositoryMtd();
                rep.SetDependencies(container.GetInstance<ILog>(), container.GetInstance<IBookRepository>());
                return rep;
            });
            container.Register<IBookRepository>(() =>
            {
                var rep = new BookRepositoryMtd();
                rep.SetLog(container.GetInstance<ILog>());
                return rep;
            });
            container.Register<ILog>(() => new ConsoleLog());
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Auto()
        {
            throw new NotImplementedException();
        }

        private class DependencyResolver : IDependencyResolver
        {
            private readonly Container _container;

            public DependencyResolver(Container container)
            {
                _container = container;
            }

            public T Resolve<T>() where T : class
            {
                return _container.GetInstance<T>();
            }
        }
    }
}