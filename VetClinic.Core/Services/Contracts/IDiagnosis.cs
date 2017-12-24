namespace VetClinic.Core.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IDiagnosis
    {
        DateTime DateCreated { get; }

        string GetDiagnosis(IAnimal pet, IEnumerable<string> symptoms);

    }
}
