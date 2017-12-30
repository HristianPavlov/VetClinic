using System.Collections.Generic;

namespace VetClinic.Data.Contracts
{
    public interface IEngineCommand
    {
        string Id { get; }

        string Name { get; }

        string PrintInfo();
    }
}
