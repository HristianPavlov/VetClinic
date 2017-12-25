namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class VetClinicPersonFactory : IVetClinicPersonFactory
    {
        public IPerson CreatePetOwner(string firstName, string lastName, string phoneNumber, string email, decimal wallet) => new PetOwner(firstName, lastName, phoneNumber, email);

        public IPerson CreateClinicStaffPerson(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            => new ClinicStaffPerson(firstName, lastName, phoneNumber, email, role);
    }
}
