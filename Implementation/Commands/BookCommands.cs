using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Commands
{
    class BookCommands : IDatabaseCommand<Book>
    {
        public Book FindById()
        {
            Console.WriteLine("BookCommands:FindById()");
            return null;
        }

        public IList<Book> GetAll()
        {
            Console.WriteLine("BookCommands:GetAll()");
            return null;
        }

        public void Save(Book entity)
        {
            Console.WriteLine("BookCommands:Save()");
        }
    }
}