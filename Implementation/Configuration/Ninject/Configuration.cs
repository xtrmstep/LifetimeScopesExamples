using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using LifetimeScopesExamples.Implementation.Repositories.Methods;
using LifetimeScopesExamples.Implementation.Repositories.Properties;
using Ninject;
using Ninject.Extensions.Conventions;

namespace LifetimeScopesExamples.Implementation.Configuration.Ninject
{
    public class Configuration : IConfiguration
    {
        public IDependencyResolver Constructors()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().To<AuthorRepositoryCtro>();
            container.Bind<IBookRepository>().To<BookRepositoryCtro>();
            container.Bind<ILog>().To<ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Expressions()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().ToConstructor(x => new AuthorRepositoryCtro(x.Inject<ILog>(), x.Inject<IBookRepository>()));
            container.Bind<IBookRepository>().ToConstructor(x => new BookRepositoryCtro(x.Inject<ILog>()));
            container.Bind<ILog>().ToConstructor(x => new ConsoleLog());
            //container.Bind<IAuthorRepository>().ToMethod(x => new AuthorRepositoryCtro(x.Kernel.Get<ILog>(), x.Kernel.Get<IBookRepository>()));
            //container.Bind<IBookRepository>().ToMethod(x => new BookRepositoryCtro(x.Kernel.Get<ILog>()));
            //container.Bind<ILog>().ToMethod(x => new ConsoleLog());

            return new DependencyResolver(container);
        }

        public IDependencyResolver Properties()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().To<AuthorRepositoryProp>();
            container.Bind<IBookRepository>().To<BookRepositoryProp>();
            container.Bind<ILog>().To<ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Methods()
        {
            var container = new StandardKernel();
            container.Bind<IAuthorRepository>().To<AuthorRepositoryMtd>().OnActivation((context, mtd) => mtd.SetDependencies(context.Kernel.Get<ILog>(), context.Kernel.Get<IBookRepository>()));
            container.Bind<IBookRepository>().To<BookRepositoryMtd>().OnActivation((context, mtd) => mtd.SetLog(context.Kernel.Get<ILog>()));
            container.Bind<ILog>().To<ConsoleLog>();

            return new DependencyResolver(container);
        }

        public IDependencyResolver Auto()
        {
            var container = new StandardKernel();
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().BindDefaultInterfaces());
            return new DependencyResolver(container);
        }

        public IDependencyResolver Module()
        {
            var container = new StandardKernel(new ImplementationModule());
            return new DependencyResolver(container);
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