using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using LifetimeScopesExamples.Implementation.Repositories.Properties;

namespace LifetimeScopesExamples.Implementation.Configuration.Windsor
{
    public static class Configuration
    {
        public static IDependencyResolver Simple()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IAuthorRepository>().ImplementedBy<AuthorRepositoryCtro>());
            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepositoryCtro>());
            container.Register(Component.For<ILog>().ImplementedBy<ConsoleLog>());

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Expressions()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IAuthorRepository>().UsingFactoryMethod(c => new AuthorRepositoryCtro(c.Resolve<ILog>(), c.Resolve<IBookRepository>())));
            container.Register(Component.For<IBookRepository>().UsingFactoryMethod(c => new BookRepositoryCtro(c.Resolve<ILog>())));
            container.Register(Component.For<ILog>().UsingFactoryMethod(c => new ConsoleLog()));

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Properties()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IAuthorRepository>().ImplementedBy<AuthorRepositoryProp>());
            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepositoryProp>());
            container.Register(Component.For<ILog>().ImplementedBy<ConsoleLog>());

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Methods()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IAuthorRepository>().ImplementedBy<AuthorRepositoryMtd>().OnCreate((c, o) => ((AuthorRepositoryMtd) o).SetDependencies(c.Resolve<ILog>(), c.Resolve<IBookRepository>())));
            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepositoryMtd>().OnCreate((c, o) => ((BookRepositoryMtd) o).SetLog(c.Resolve<ILog>())));
            container.Register(Component.For<ILog>().ImplementedBy<ConsoleLog>());

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Auto()
        {
            var container = new WindsorContainer();
            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
                .IncludeNonPublicTypes()
                .Pick()
                .WithService.DefaultInterfaces());
            return new DependencyResolver(container);
        }

        private class DependencyResolver : IDependencyResolver
        {
            private readonly WindsorContainer _container;

            public DependencyResolver(WindsorContainer container)
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