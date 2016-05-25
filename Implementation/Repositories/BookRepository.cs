using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly ILog _log;

        public BookRepository(ILog log)
        {
            _log = log;
        }

        public IList<Book> FindByParent(int parentId)
        {
            _log.Write("BookRepository:FindByParent()");
            return null;
        }
    }
}