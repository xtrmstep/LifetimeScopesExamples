using System;
using System.Collections.Generic;
using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;

namespace LifetimeScopesExamples.Implementation.Repositories.Methods
{
    internal class BookRepositoryMtd : IBookRepository
    {
        private static int _counter;
        private ILog _log;

        public BookRepositoryMtd()
        {
            _counter++;
            Console.WriteLine("[B{0}] BookRepositoryMtd:ctor", _counter);
        }

        public IList<Book> FindByParent(int parentId)
        {
            _log.Write("BookRepository:FindByParent()");
            return null;
        }

        public void SetLog(ILog log)
        {
            _log = log;
        }
    }
}