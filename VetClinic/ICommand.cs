using System.Collections.Generic;

namespace VetClinic
{
    internal interface ICommand
    {
        string Name { get; }

       // List<string> Parameters { get; }
    }
}