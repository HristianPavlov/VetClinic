namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using Common.Enums;
    using System.Text;
    using VetClinic.Data.Contracts;

    public class Cat : Pet, ICat
    {
        public Cat(string name, AnimalGenderType gender, int age) 
            : base(name, gender, AnimalType.Cat, age)
        {
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();
        }

        public override string PrintInfo() => base.PrintInfo();
    }
}
