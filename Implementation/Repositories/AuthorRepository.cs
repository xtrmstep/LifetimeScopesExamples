using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly ILog _log;
        private readonly IBookRepository _bookRepository;

        public AuthorRepository(ILog log, IBookRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }

        public IList<Book> GetBooks(Author parent)
        {
            _log.Write("AuthorRepository:GetBooks()");
            return _bookRepository.FindByParent(parent.Id);
        }
    }
}