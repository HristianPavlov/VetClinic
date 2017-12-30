using System;
using System.Text;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Common
{
    public static class IdGenerator
    {
        public static string GenerateId(object classType)
        {
            var sb = new StringBuilder();
            var id = Guid.NewGuid().ToString();

            switch (classType)
            {
                case Type person when person == typeof(IPerson): sb.Append("P"); break;
                case Type pet when pet == typeof(IPet): sb.Append("A"); break;
                default: Console.WriteLine(("No such type found")); break;
            }

            sb.Append(id);

            return sb.ToString();
        }
}
}
