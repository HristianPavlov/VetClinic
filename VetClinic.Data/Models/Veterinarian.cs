namespace VetClinic.Data.Models
{
    using Contracts;

    public class Veterinarian : Staff, IIdentifiable
    {
        private string Prescription = string.Empty;

        public Veterinarian(string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
        }
    }
}
