using System;
using LifetimeScopesExamples.Abstraction;

namespace LifetimeScopesExamples.Implementation
{
    internal class ConsoleLog : ILog
    {
        private static int _counter;

        public ConsoleLog()
        {
            _counter++;
            Console.WriteLine("[C{0}] ConsoleLog:ctor", _counter);
        }

        public void Write(string text)
        {
            Console.WriteLine("[C{0}] {1}", _counter, text);
        }
    }
}