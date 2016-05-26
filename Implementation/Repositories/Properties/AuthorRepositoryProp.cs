using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Properties
{
    internal class AuthorRepositoryProp : IAuthorRepository
    {
        public ILog Log { get; set; }
        public IBookRepository BookRepository { get; set;  }

        public IList<Book> GetBooks(Author parent)
        {
            Log.Write("AuthorRepository:GetBooks()");
            return BookRepository.FindByParent(parent.Id);
        }
    }
}