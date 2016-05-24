using System.Collections.Generic;

namespace LifetimeScopesExamples.Abstraction
{
    public interface IDatabaseCommand<T>
    {
        IList<T> GetAll();
        T FindById();
        void Save(T entity);
    }
}