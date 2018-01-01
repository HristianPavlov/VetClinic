namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class PersonFactory : Factory, IPersonFactory
    {
        public IUser CreateUser(string firstName, string lastName, string phoneNumber, string email) => new User(firstName, lastName, phoneNumber, email);

        public IEmployee CreateEmployee(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            => new Employee(firstName, lastName, phoneNumber, email, role);
    }
}
