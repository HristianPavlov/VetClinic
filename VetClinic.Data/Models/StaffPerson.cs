namespace VetClinic.Data.Models
{
    using Abstractions;
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Contracts;

    public class StaffPerson : Person, IStaffPerson
    {
        private readonly RoleType role;

        public StaffPerson(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.role = role;
        }

        public RoleType Role => this.role;
    }
}
