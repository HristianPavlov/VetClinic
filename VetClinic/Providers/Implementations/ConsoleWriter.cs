namespace VetClinic.Providers.ConsoleServices.Implementations
{
    using System;
    using VetClinic.Providers.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value);

        public void WriteLine(object value) => Console.WriteLine(value.ToString().TrimEnd());
    }
}
