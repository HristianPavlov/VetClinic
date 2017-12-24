namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using Common.Enums;
    using Contracts;
    using System.Text;
    using VetClinic.Data.Common;

    public abstract class Animal : IAnimal
    {
        private readonly string id;
        private readonly string name;
        private readonly int? age;

        public Animal(string name, AnimalGenderType gender, AnimalType type, int age = 0)
        {
            Guard.WhenArgument(name, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();

            id = IdGenerator.GenerateId(typeof(IAnimal));
            this.name = name;
            this.Gender = gender;
            this.Age = age;
            this.Type = type;
        }

        public string Id => this.id;

        public string Name => this.name;

        public int Age { get; protected set; }

        public PetOwner Owner { get; protected set; }

        public AnimalType Type { get; protected set; }

        public AnimalGenderType Gender { get; protected set; }

        static int animalsCount = 0;

        public string GenerateId()
        {
            var sb = new StringBuilder();

            animalsCount++;
            sb.Append('A');
            sb.Append(animalsCount);

            return sb.ToString();
        }

        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Pet Type: {this.Type}");
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Gender: {this.Gender}");

            return sb.ToString();
        }
    }
}
