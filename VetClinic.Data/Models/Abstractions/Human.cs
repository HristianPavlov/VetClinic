namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;

    public abstract class Human
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;

        public Human(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                Guard.WhenArgument(value, "First name is null or empty").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "First name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                Guard.WhenArgument(value, "Last name is null or empty").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "Last name has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
                this.lastName = value;
            }
        }

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                Guard.WhenArgument(value, "Phone number is null or empty").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "Phone number has invalid length").IsLessThan(3).IsGreaterThan(15).Throw();
                this.phoneNumber = value;
            }
        }

    }
}
