namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;

    public interface IVetClinicPersonFactory
    {
        IPerson CreatePetOwner(string firstName, string lastName, string phoneNumber, string email, decimal wallet);

        IPerson CreateClinicStaffPerson(string firstName, string lastName, string phoneNumber, string email, RoleType role);
    }
}
