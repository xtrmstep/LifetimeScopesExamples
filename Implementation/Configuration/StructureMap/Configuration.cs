using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using LifetimeScopesExamples.Implementation.Repositories.Properties;
using StructureMap;
using StructureMap.Graph;

namespace LifetimeScopesExamples.Implementation.Configuration.StructureMap
{
    public static class Configuration
    {
        public static IDependencyResolver Simple()
        {
            var container = new Container();
            container.Configure(c =>
            {
                c.For<IAuthorRepository>().Use<AuthorRepositoryCtro>();
                c.For<IBookRepository>().Use<BookRepositoryCtro>();
                c.For<ILog>().Use<ConsoleLog>();
            });

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Expressions()
        {
            var container = new Container();
            container.Configure(c =>
            {
                c.For<IAuthorRepository>().Use(cntr => new AuthorRepositoryCtro(cntr.GetInstance<ILog>(), cntr.GetInstance<IBookRepository>()));
                c.For<IBookRepository>().Use(cntr => new BookRepositoryCtro(cntr.GetInstance<ILog>()));
                c.For<ILog>().Use(() => new ConsoleLog());
            });
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Properties()
        {
            var container = new Container();
            container.Configure(c =>
            {
                c.For<IAuthorRepository>().Use<AuthorRepositoryProp>();
                c.For<IBookRepository>().Use<BookRepositoryProp>();
                c.For<ILog>().Use(() => new ConsoleLog());
                c.Policies.SetAllProperties(x =>
                {
                    x.OfType<IAuthorRepository>();
                    x.OfType<IBookRepository>();
                    x.OfType<ILog>();
                });
            });
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Methods()
        {
            var container = new Container();
            container.Configure(c =>
            {
                c.For<IAuthorRepository>().Use<AuthorRepositoryMtd>().OnCreation((ctx, obj) => obj.SetDependencies(ctx.GetInstance<ILog>(), ctx.GetInstance<IBookRepository>()));
                c.For<IBookRepository>().Use<BookRepositoryMtd>().OnCreation((ctx, obj) => obj.SetLog(ctx.GetInstance<ILog>()));
                c.For<ILog>().Use<ConsoleLog>();
            });

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Auto()
        {
            /*
             * Make sure the implementation classes are PUBLIC
             */
            var container = new Container();
            container.Configure(c => c.Scan(x =>
            {
                x.TheCallingAssembly();
                //x.With(new FirstInterfaceConvention());
                x.RegisterConcreteTypesAgainstTheFirstInterface();
            }));

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Module()
        {
            var registry = new Registry();
            registry.IncludeRegistry<ImplementationModule>();
            var container = new Container(registry);
            return new DependencyResolver(container);
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