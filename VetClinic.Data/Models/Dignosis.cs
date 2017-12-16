namespace VetClinic.Data.Models
{
    using Abstractions;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Dignosis : IDiagnosis
    {
        public Dignosis()
        {

        }

        public DateTime DateOfDiagnosis
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string GetDiagnosis(Animal pet, IEnumerable<string> symptoms)
        {
            throw new NotImplementedException();
        }
    }
}
