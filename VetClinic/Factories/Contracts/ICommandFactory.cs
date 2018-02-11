using System;
using System.Collections.Generic;

namespace VetClinic.Factories.Contracts
{
    public interface ICommandFactory
    {
        List<Type> GetAllCommands();

        object ResolveCommand(string commandAsString);
    }
}
