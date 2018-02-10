using System;
using System.Collections.Generic;

namespace VetClinic.Factories.Contracts
{
    public interface ICommandFactory
    {
        List<Type> GetCommandClasses();
    }
}
