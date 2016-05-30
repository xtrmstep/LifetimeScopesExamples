using Autofac;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Implementation.Repositories.Constructors;

namespace LifetimeScopesExamples.Implementation.Configuration.Autofac
{
    public class ImplementationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorRepositoryCtro>().As<IAuthorRepository>();
            builder.RegisterType<BookRepositoryCtro>().As<IBookRepository>();
            builder.RegisterType<ConsoleLog>().As<ILog>();
        }
    }
}