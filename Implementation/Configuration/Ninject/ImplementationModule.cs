using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using Ninject.Modules;

namespace LifetimeScopesExamples.Implementation.Configuration.Ninject
{
    public class ImplementationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorRepository>().To<AuthorRepositoryCtro>();
            Bind<IBookRepository>().To<BookRepositoryCtro>();
            Bind<ILog>().To<ConsoleLog>();
        }
    }
}