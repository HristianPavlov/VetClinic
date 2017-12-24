namespace VetClinic.Core.Services.Implementations
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public class Diagnosis : IDiagnosis
    {
        private readonly DateTime dateCreated;

        public Diagnosis(DateTime dateCreated)
        {
            this.dateCreated = DateTime.UtcNow;
        }

        public DateTime DateCreated => this.dateCreated;

        public string GetDiagnosis(IAnimal pet, IEnumerable<string> symptoms)
        {
            throw new NotImplementedException();
        }
    }
}
