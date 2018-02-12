using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface ICommand
    {
        void Execute();

        IList<string> Parameters { get; set; }
    }
}
