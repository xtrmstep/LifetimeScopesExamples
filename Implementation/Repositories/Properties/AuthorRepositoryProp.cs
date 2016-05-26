using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Properties
{
    internal class AuthorRepositoryProp : IAuthorRepository
    {
        private static int _counter;

        public AuthorRepositoryProp()
        {
            _counter++;
            Console.WriteLine("[A{0}] AuthorRepositoryProp:ctor", _counter);
        }

        public ILog Log { get; set; }
        public IBookRepository BookRepository { get; set; }

        public IList<Book> GetBooks(Author parent)
        {
            Log.Write("AuthorRepository:GetBooks()");
            return BookRepository.FindByParent(parent.Id);
        }
    }
}