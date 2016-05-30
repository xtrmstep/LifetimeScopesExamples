using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;

namespace LifetimeScopesExamples.Implementation.Configuration.Windsor
{
    public class ImplementationModule : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuthorRepository>().ImplementedBy<AuthorRepositoryCtro>());
            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepositoryCtro>());
            container.Register(Component.For<ILog>().ImplementedBy<ConsoleLog>());
        }
    }
}