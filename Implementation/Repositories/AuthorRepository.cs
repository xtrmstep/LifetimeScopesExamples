using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories
{
    class AuthorRepository : IRepository<Author>
    {
        public IList<Author> GetParents(Author parent)
        {
            Console.WriteLine("AuthorRepository:GetParents()");
            return null;
        }

        public void SetParent(IList<Author> list, Author parent)
        {
            Console.WriteLine("AuthorRepository:SetParent()");
        }
    }
}