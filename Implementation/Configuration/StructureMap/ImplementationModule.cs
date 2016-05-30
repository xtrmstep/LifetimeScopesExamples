using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;
using StructureMap;

namespace LifetimeScopesExamples.Implementation.Configuration.StructureMap
{
    public class ImplementationModule : Registry
    {
        public ImplementationModule()
        {
            For<IAuthorRepository>().Use<AuthorRepositoryCtro>();
            For<IBookRepository>().Use<BookRepositoryCtro>();
            For<ILog>().Use<ConsoleLog>();
        }
    }
}