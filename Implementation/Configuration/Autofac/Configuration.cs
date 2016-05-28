using System.Reflection;
using Autofac;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;

namespace LifetimeScopesExamples.Implementation.Configuration.Autofac
{
    public static class Configuration
    {
        public static IDependencyResolver Simple()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthorRepositoryCtro>().As<IAuthorRepository>();
            builder.RegisterType<BookRepositoryCtro>().As<IBookRepository>();
            builder.RegisterType<ConsoleLog>().As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Expressions()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new AuthorRepositoryCtro(c.Resolve<ILog>(), c.Resolve<IBookRepository>())).As<IAuthorRepository>();
            builder.Register(c => new BookRepositoryCtro(c.Resolve<ILog>())).As<IBookRepository>();
            builder.Register(c => new ConsoleLog()).As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Properties()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthorRepositoryCtro>().As<IAuthorRepository>().PropertiesAutowired();
            builder.RegisterType<BookRepositoryCtro>().As<IBookRepository>().PropertiesAutowired();
            builder.RegisterType<ConsoleLog>().As<ILog>();
            var container = builder.Build();
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Methods()
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

        public static IDependencyResolver Auto()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            //todo which exactly implementation is registered?
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