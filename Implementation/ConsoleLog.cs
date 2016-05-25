using System;
using LifetimeScopesExamples.Abstraction;

namespace LifetimeScopesExamples.Implementation
{
    internal class ConsoleLog : ILog
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}