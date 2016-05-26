using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Properties
{
    internal class BookRepositoryProp : IBookRepository
    {
        public ILog Log { get; set; }

        public IList<Book> FindByParent(int parentId)
        {
            Log.Write("BookRepository:FindByParent()");
            return null;
        }
    }
}