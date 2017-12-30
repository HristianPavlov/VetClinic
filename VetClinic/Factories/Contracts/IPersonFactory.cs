namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;

    public interface IPersonFactory
    {
        IUser CreateUser(string firstName, string lastName, string phoneNumber, string email);

        IEmployee CreateEmployee(string firstName, string lastName, string phoneNumber, string email, RoleType role);
    }
}
