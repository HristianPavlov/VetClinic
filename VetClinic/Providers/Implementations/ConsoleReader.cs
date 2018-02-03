namespace VetClinic.Providers.ConsoleServices.Implementations
{
    using System;
    using VetClinic.Providers.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
