using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using Microsoft.Practices.Unity;

namespace LifetimeScopesExamples.Implementation.Configuration.Unity
{
    public class ImplementationModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAuthorRepository, AuthorRepositoryCtro>();
            Container.RegisterType<IBookRepository, BookRepositoryCtro>();
            Container.RegisterType<ILog, ConsoleLog>();
        }
    }
}