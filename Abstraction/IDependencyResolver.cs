namespace LifetimeScopesExamples.Abstraction
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}