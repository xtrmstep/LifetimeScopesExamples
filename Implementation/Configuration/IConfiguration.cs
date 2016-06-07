using LifetimeScopesExamples.Abstraction;

namespace LifetimeScopesExamples.Implementation.Configuration
{
    public interface IConfiguration
    {
        IDependencyResolver Constructors();
        IDependencyResolver Properties();
        IDependencyResolver Methods();
        IDependencyResolver Expressions();
        IDependencyResolver Auto();
        IDependencyResolver Module();
    }
}