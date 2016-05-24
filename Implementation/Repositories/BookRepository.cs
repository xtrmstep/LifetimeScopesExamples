using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories
{
    class BookRepository : IRepository<Book>
    {
        public IList<Book> GetParents(Book parent)
        {
            Console.WriteLine("BookRepository:GetParents()");
            return null;
        }

        public void SetParent(IList<Book> list, Book parent)
        {
            Console.WriteLine("BookRepository:SetParent()");
        }
    }
}
