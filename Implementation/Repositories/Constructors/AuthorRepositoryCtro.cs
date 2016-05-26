using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Constructors
{
    internal class AuthorRepositoryCtro : IAuthorRepository
    {
        private static int _counter;
        private readonly IBookRepository _bookRepository;
        private readonly ILog _log;

        public AuthorRepositoryCtro(ILog log, IBookRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
            _counter++;
            Console.WriteLine("[A{0}] AuthorRepositoryCtro:ctor", _counter);
        }

        public IList<Book> GetBooks(Author parent)
        {
            _log.Write("AuthorRepository:GetBooks()");
            return _bookRepository.FindByParent(parent.Id);
        }
    }
}