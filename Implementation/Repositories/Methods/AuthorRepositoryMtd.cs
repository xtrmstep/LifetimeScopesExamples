using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Methods
{
    internal class AuthorRepositoryMtd : IAuthorRepository
    {
        private IBookRepository _bookRepository;
        private ILog _log;

        public IList<Book> GetBooks(Author parent)
        {
            _log.Write("AuthorRepository:GetBooks()");
            return _bookRepository.FindByParent(parent.Id);
        }

        public void SetDependencies(ILog log, IBookRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }
    }
}