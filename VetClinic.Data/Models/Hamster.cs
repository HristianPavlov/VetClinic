namespace VetClinic.Data.Models
{
    using Abstractions;
    using Bytes2you.Validation;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Enums;

    public class Hamster : Pet, IHamster
    {
        public Hamster(string name, AnimalGenderType gender, int age) 
            : base(name, gender, AnimalType.Hamster, age)
        {
            Guard.WhenArgument(age, "Age cannot be less than zero").IsLessThan(0).Throw();
        }

        public override string PrintInfo() => base.PrintInfo();
    }
}
