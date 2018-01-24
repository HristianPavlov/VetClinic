namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using System;
    using System.Text;
    using VetClinic.Data.Contracts;

    public abstract class Person : IPerson
    {
        private readonly string id;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string phoneNumber;
        private readonly string email;

        public Person(string firstName, string lastName, string phoneNumber, string email)
        {
            Guard.WhenArgument(firstName, "First name is null or empty").IsNullOrEmpty().Throw();
            Guard.WhenArgument(firstName.Length, "First name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
            Guard.WhenArgument(lastName, "Last name is null or empty").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName.Length, "Last name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
            Guard.WhenArgument(phoneNumber, "Phone number is null or empty").IsNullOrEmpty().Throw();
            Guard.WhenArgument(phoneNumber.Length, "Phone number has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();

            this.id = Guid.NewGuid().ToString();
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public string Id => this.id;

        public string FirstName => this.firstName;

        public string LastName => this.lastName;

        public string PhoneNumber => this.phoneNumber;

        public string Email => this.email;

        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Full Name: {this.FirstName} {this.LastName}");
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Phone Number: {this.PhoneNumber}");
            sb.AppendLine($"Email: {this.Email}");

            return sb.ToString();
        }

    }
}
