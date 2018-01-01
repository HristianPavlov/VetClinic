namespace VetClinic.Common.ConsoleServices.Implementations
{
    using System;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value);

        public void WriteLine(object value) => Console.WriteLine(value.ToString().Trim());
    }
}
