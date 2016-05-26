using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;
using LifetimeScopesExamples.Implementation.Configuration.Autofac;

namespace LifetimeScopesExamples.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var resolver = Configuration.Auto();
            System.Console.WriteLine("DI container is built.");

            /*  both resolving use the same method of IBookRepository
             *  it depends on lifetime scope configuration whether ILog would be the same instance
             *  (the number in the output shows the number of the instance)
             */

            // the 1st resolving
            var books = resolver.Resolve<IAuthorRepository>().GetBooks(new Author());

            // the 2nd resolving
            resolver.Resolve<IBookRepository>().FindByParent(0);

            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }
    }
}