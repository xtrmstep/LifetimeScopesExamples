using System;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
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
                c.For<IAuthorRepository>().Use<AuthorRepositoryCtro>();
                c.For<IBookRepository>().Use<BookRepositoryCtro>();
                c.For<ILog>().Use(() => new ConsoleLog());
                c.Policies.SetAllProperties(convention => { });
            });
            return new DependencyResolver(container);
        }

        public static IDependencyResolver Methods()
        {
            //todo structuremap method injection
            throw new NotImplementedException();
            //var container = new Container();
            //container.Configure(c =>
            //{
            //    c.For<IAuthorRepository>().Use(cntr =>
            //    {
            //        var rep = new AuthorRepositoryMtd();
            //        rep.SetDependencies(container.GetInstance<ILog>(), container.GetInstance<IBookRepository>());
            //        return rep;
            //    });
            //    c.For<IBookRepository>().Use(cntr =>
            //    {
            //        var rep = new BookRepositoryMtd();
            //        rep.SetLog(container.GetInstance<ILog>());
            //        return rep;
            //    });
            //    c.For<ILog>().Use(() => new ConsoleLog());
            //});

            //return new DependencyResolver(container);
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