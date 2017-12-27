namespace VetClinic.Data.Models
{
    using Common.Enums;
    using Abstractions;
    using Bytes2you.Validation;
    using VetClinic.Data.Contracts;
    using System.Text;

    public class Hamster : Animal, IHamster
    {
        public Hamster(string name, AnimalGenderType gender, int age) 
            : base(name, gender, AnimalType.Hamster, age)
        {
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();
        }

        public override string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Pet Type: {this.Type}");
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Gender: {this.Gender}");
            sb.AppendLine($"Age: {this.Age} years");

            return sb.ToString();
        }
    }
}
