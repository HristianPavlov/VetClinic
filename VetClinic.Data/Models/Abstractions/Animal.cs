namespace VetClinic.Data.Models.Abstractions
{
    using Bytes2you.Validation;
    using Common.Enums;
    using Contracts;
    using System;
    using System.Text;

    public abstract class Animal : IAnimal
    {
        private readonly string id;
        private readonly string name;
        private readonly int age;
        private readonly AnimalGenderType gender;

        public Animal(string name, AnimalGenderType gender, AnimalType type, int age = 0)
        {
            Guard.WhenArgument(name, "Invalid name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Invalid name length").IsLessThan(2).IsGreaterThan(15).Throw();

            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.Type = type;
        }

        public string Id => this.id;

        public string Name => this.name;

        public int Age => this.age;

        public AnimalGenderType Gender => this.gender;

        public User Owner { get; protected set; }

        public AnimalType Type { get; protected set; }

        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Pet Type: {this.Type}");
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Gender: {this.Gender}");

            return sb.ToString();
        }
    }
}
