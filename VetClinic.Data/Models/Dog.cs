namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using System.Text;
    using Common.Enums;
    using Abstractions;

    public class Dog : Animal
    {
        private string breed;
        private int age;

        public Dog(string name, GenderType gender, int age, string breed) 
            : base(name, gender, AnimalType.Dog)
        {
            this.Breed = breed;
            this.Age = age;
           // this.Type = AnimalType.Dog;
        }

        public int Age
        {
            get => this.age;
            private set
            {
                Guard.WhenArgument(value, "Age less than zero").IsLessThan(0).Throw();
                this.age = value;
            }

        }
        public string Breed
        {
            get => breed;
            private set
            {
                Guard.WhenArgument(value, "Invalid name").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();
                this.breed = value;

            }
        }

        public override string PrintInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Pet Type: {this.Type}");
            str.AppendLine($"Breed: {this.Breed}");
            str.AppendLine($"Name: {this.Name}");
            str.AppendLine($"Gender: {this.Gender}");
            str.AppendLine($"Age: {this.Age} years");
            str.AppendLine($"ID: {this.ID}");

            return str.ToString();

        }
    }
}