using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Methods
{
    internal class BookRepositoryMtd : IBookRepository
    {
        private ILog _log;

        public IList<Book> FindByParent(int parentId)
        {
            _log.Write("BookRepository:FindByParent()");
            return null;
        }

        public void SetLog(ILog log)
        {
            _log = log;
        }
    }
}