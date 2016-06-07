using System.Reflection;
using Autofac;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;

namespace LifetimeScopesExamples.Implementation.Configuration.Autofac
{
    public class Configuration : IConfiguration
    {
        public IDependencyResolver Constructors()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthorRepositoryCtro>().As<IAuthorRepository>();
            builder.RegisterType<BookRepositoryCtro>().As<IBookRepository>();
            builder.RegisterType<ConsoleLog>().As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public IDependencyResolver Expressions()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new AuthorRepositoryCtro(c.Resolve<ILog>(), c.Resolve<IBookRepository>())).As<IAuthorRepository>();
            builder.Register(c => new BookRepositoryCtro(c.Resolve<ILog>())).As<IBookRepository>();
            builder.Register(c => new ConsoleLog()).As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public IDependencyResolver Properties()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthorRepositoryCtro>().As<IAuthorRepository>().PropertiesAutowired();
            builder.RegisterType<BookRepositoryCtro>().As<IBookRepository>().PropertiesAutowired();
            builder.RegisterType<ConsoleLog>().As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public IDependencyResolver Methods()
        {
            var builder = new ContainerBuilder();
            builder.Register(c =>
            {
                var rep = new AuthorRepositoryMtd();
                rep.SetDependencies(c.Resolve<ILog>(), c.Resolve<IBookRepository>());
                return rep;
            }).As<IAuthorRepository>();
            builder.Register(c =>
            {
                var rep = new BookRepositoryMtd();
                rep.SetLog(c.Resolve<ILog>());
                return rep;
            }).As<IBookRepository>();
            builder.Register(c => new ConsoleLog()).As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public IDependencyResolver Auto()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public IDependencyResolver Module()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ImplementationModule());
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

            public T Resolve<T>() where T : class
            {
                return _container.Resolve<T>();
            }
        }
    }
}