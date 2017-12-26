namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using Common.Enums;
    using System.Text;
    using VetClinic.Data.Contracts;

    public class Cat : Animal, ICat
    {
        public Cat(string name, AnimalGenderType gender, int age) 
            : base(name, gender, AnimalType.Cat, age)
        {
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();
        }

        public override string PrintInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Id: {this.Id}");
            str.AppendLine($"Pet Type: {this.Type}");
            str.AppendLine($"Name: {this.Name}");
            str.AppendLine($"Gender: {this.Gender}");
            str.AppendLine($"Age: {this.Age}");

            return str.ToString();

        }

    }
}
