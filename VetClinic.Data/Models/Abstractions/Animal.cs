namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using Common.Enums;
    using Contracts;
    using System.Text;

    public abstract class Animal : IIdentifiable, IAnimal
    {
        private readonly string id;
        private readonly string name;
        private readonly int age;
        private readonly Owner owner;

        public Animal(string id, string name, int age, Owner owner, AnimalGenderType gender, AnimalType type)
        {
            Guard.WhenArgument(name, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();

            this.id = GenerateId();
            this.name = name;
            this.age = age;
            this.owner = owner;
            this.Gender = gender;          
            this.Type = type;
        }

        public string Id => this.id;

        public string Name => this.name;

        public int Age => this.age;

        public Owner Owner => this.Owner;

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
