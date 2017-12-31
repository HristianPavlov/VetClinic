namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        List<string> GetAllCommands();
    }
}
