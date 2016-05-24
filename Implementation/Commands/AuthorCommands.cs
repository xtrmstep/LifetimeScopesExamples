using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Commands
{
    class AuthorCommands : IDatabaseCommand<Author>
    {
        public Author FindById()
        {
            Console.WriteLine("AuthorCommands:FindById()");
            return null;
        }

        public IList<Author> GetAll()
        {
            Console.WriteLine("AuthorCommands:GetAll()");
            return null;
        }

        public void Save(Author entity)
        {
            Console.WriteLine("AuthorCommands:Save()");
        }
    }
}