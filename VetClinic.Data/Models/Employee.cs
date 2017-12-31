namespace VetClinic.Data.Models
{
    using Abstractions;
    using System.Text;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;

    public class Employee : Person, IEmployee
    {
        private readonly RoleType role;

        public Employee(string firstName, string lastName, string phoneNumber, string email, RoleType role)
            : base(firstName, lastName, phoneNumber, email)
        {
            this.role = role;
        }

        public RoleType Role => this.role;

        public override string PrintInfo()
        {
            var sb = new StringBuilder();
            sb.Append(base.PrintInfo());
            sb.AppendLine($"Role: {this.Role}");
            return sb.ToString();
        }
    }
}
