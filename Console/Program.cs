using LifetimeScopesExamples.Abstraction;
using LifetimeScopesExamples.Abstraction.Model;
using LifetimeScopesExamples.Implementation.Configuration.Autofac;

namespace LifetimeScopesExamples.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var resolver = Configuration.Methods();

            var books = resolver.Resolve<IAuthorRepository>().GetBooks(new Author());

            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }
    }
}