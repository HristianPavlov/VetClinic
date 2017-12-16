namespace VetClinic.Data.Contracts
{
    using VetClinic.Data.Models;
    using System;
    using System.Collections.Generic;

    public interface IDiagnosis
    {
        DateTime DateOfDiagnosis { get; set; }

        string GetDiagnosis(Animal pet, IEnumerable<string> symptoms);

        //void GetDiagnosis(IAnimal pet, Dictionary<IEnumerable<string>,IEnumerable<string>> symptoms);

    }
}
