namespace VetClinic.Common.ConsoleServices.Implementations
{
    using System;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
