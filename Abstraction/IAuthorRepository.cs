using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Abstraction
{
    public interface IAuthorRepository
    {
        IList<Book> GetBooks(Author parent);
    }
}