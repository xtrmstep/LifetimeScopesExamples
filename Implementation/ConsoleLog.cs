using System;
using LifetimeScopesExamples.Abstraction;

namespace LifetimeScopesExamples.Implementation
{
    internal class ConsoleLog : ILog
    {
        private static int _counter = 0;

        public ConsoleLog()
        {
            _counter++;
        }

        public void Write(string text)
        {
            Console.WriteLine("[{0}] {1}", _counter, text);
        }
    }
}