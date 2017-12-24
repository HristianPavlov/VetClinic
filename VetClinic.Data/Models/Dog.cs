namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using System.Text;
    using Common.Enums;
    using Abstractions;
    using VetClinic.Data.Contracts;

    public class Dog : Animal, IDog
    {
        private readonly string breed;

        public Dog(string name, AnimalGenderType gender, string breed, int age) 
            : base(name, gender, AnimalType.Dog, age)
        {
            Guard.WhenArgument(breed, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(breed.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();

            this.breed = breed;
        }

        public string Breed => this.breed;

        public override string PrintInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Pet Type: {this.Type}");
            str.AppendLine($"Breed: {this.Breed}");
            str.AppendLine($"Name: {this.Name}");
            str.AppendLine($"Gender: {this.Gender}");
            str.AppendLine($"Age: {this.Age} years");
            str.AppendLine($"Id: {this.Id}");

            return str.ToString();

        }
    }
}