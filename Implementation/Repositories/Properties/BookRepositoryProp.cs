using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Properties
{
    internal class BookRepositoryProp : IBookRepository
    {
        private static int _counter;

        public BookRepositoryProp()
        {
            _counter++;
            Console.WriteLine("[B{0}] BookRepositoryProp:ctor", _counter);
        }

        public ILog Log { get; set; }

        public IList<Book> FindByParent(int parentId)
        {
            Log.Write("BookRepository:FindByParent()");
            return null;
        }
    }
}