using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Abstraction
{
    public interface IBookRepository
    {
        IList<Book> FindByParent(int parentId);
    }
}