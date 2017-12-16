namespace VetClinic.Data.Models
{
    using System;
    using Contracts;

    public class Veterinarian : Staff, IIdentifiable
    {
        private string Prescription = string.Empty;

        public Veterinarian(string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
        }

        public void GivePrescription(IDiagnosis dignosis)
        {
            throw new NotImplementedException();
        }
    }
}
