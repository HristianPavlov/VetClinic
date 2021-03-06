﻿namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using System.Text;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;

    public class Dog : Pet, IDog
    {
        private readonly string breed;

        public Dog(string name, AnimalGenderType gender, string breed, int age)
            : base(name, gender, AnimalType.dog, age)
        {
            Guard.WhenArgument(breed, "Invalid breed").IsNull().Throw();
            Guard.WhenArgument(breed.Length, "Invalid breed length").IsLessThan(2).IsGreaterThan(15).Throw();
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();

            this.breed = breed;
        }

        public string Breed => this.breed;

        public override string PrintInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.PrintInfo().Trim());
            sb.AppendLine($"Breed: {this.Breed}");
            return sb.ToString();
        }
    }
}