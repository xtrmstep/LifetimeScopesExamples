using System.Collections.Generic;

namespace LifetimeScopesExamples.Abstraction
{
    public interface IRepository<T>
    {
        IList<T> GetParents(T parent);
        void SetParent(IList<T> list, T parent);
    }
}