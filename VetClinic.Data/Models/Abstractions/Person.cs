namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using VetClinic.Data.Common;
    using VetClinic.Data.Contracts;

    public abstract class Person: IPerson
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
            Guard.WhenArgument(lastName, "First name is null or empty").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName.Length, "First name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
            Guard.WhenArgument(phoneNumber, "First name is null or empty").IsNullOrEmpty().Throw();
            Guard.WhenArgument(phoneNumber.Length, "First name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();

            id = IdGenerator.GenerateId(typeof(IPerson));
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public string FirstName => this.firstName;

        public string LastName => this.lastName;

        public string PhoneNumber => this.phoneNumber;

        public string Id => this.Id;

        public string Email => this.Email;

    }
}
