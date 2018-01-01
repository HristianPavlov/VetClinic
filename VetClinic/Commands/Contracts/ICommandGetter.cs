namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface ICommandGetter
    {
        List<string> GetAllCommands();
    }
}
