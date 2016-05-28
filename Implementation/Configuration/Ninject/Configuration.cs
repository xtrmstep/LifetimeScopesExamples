using System;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Properties;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using Ninject;

namespace LifetimeScopesExamples.Implementation.Configuration.Ninject
{
    public static class Configuration
    {
        public static IDependencyResolver Simple()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().To<AuthorRepositoryCtro>();
            container.Bind<IBookRepository>().To<BookRepositoryCtro>();
            container.Bind<ILog>().To<ConsoleLog>();

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Expressions()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().ToConstructor(x => new AuthorRepositoryCtro(x.Inject<ILog>(), x.Inject<IBookRepository>()));
            container.Bind<IBookRepository>().ToConstructor(x => new BookRepositoryCtro(x.Inject<ILog>()));
            container.Bind<ILog>().ToConstructor(x => new ConsoleLog());

            return new DependencyResolver(container);
        }

        public static IDependencyResolver Properties()
        {
            throw new NotImplementedException();
            //var container = new Container();
            //container.Configure(c =>
            //{
            //    c.For<IAuthorRepository>().Use<AuthorRepositoryCtro>();
            //    c.For<IBookRepository>().Use<BookRepositoryCtro>();
            //    c.For<ILog>().Use(() => new ConsoleLog());
            //    c.Policies.SetAllProperties(convention => { });
            //});
            //return new DependencyResolver(container);
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
            throw new NotImplementedException();
            /*
             * Make sure the implementation classes are PUBLIC
             */
            //var container = new Container();
            //container.Configure(c => c.Scan(x =>
            //{
            //    x.TheCallingAssembly();
            //    //x.With(new FirstInterfaceConvention());
            //    x.RegisterConcreteTypesAgainstTheFirstInterface();
            //}));

            //return new DependencyResolver(container);
        }

        private class DependencyResolver : IDependencyResolver
        {
            private readonly StandardKernel _container;

            public DependencyResolver(StandardKernel container)
            {
                _container = container;
            }

            public T Resolve<T>() where T : class
            {
                return _container.Get<T>();
            }
        }
    }
}
