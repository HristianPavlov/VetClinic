namespace VetClinic.Data.Models
{
    using Abstractions;
    using VetClinic.Data.Common.Enums;

    public class ClinicStaffPerson : Person
    {
        private readonly RoleType role;

        public ClinicStaffPerson(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.role = role;
        }

        public RoleType Role => this.role;
    }
}
