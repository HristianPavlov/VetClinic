namespace VetClinic.Data.Models
{
    using Bytes2you.Validation;
    using Contracts;

    public class Medicine : Supplies, ISuppliable
    {
        private string name;
        //private Disease disease;
        private static int quantity = 50; // divide by disease types

        public Medicine(string name)
        : base(name)
        {
            this.Name = name;

        }

        //public Medicine(string name, Disease disease)
        //    : base(name)
        //{
        //    this.Name = name;
        //    this.Disease = disease;
        //}

        //public Disease Disease
        //{
        //    get => this.disease;
        //    set
        //    {
        //        if (!Enum.IsDefined(typeof(Disease), disease))
        //        {
        //            throw new ArgumentException("Invalid disease type");
        //        }
        //        this.disease = value;
        //    }
        //}

        public override int Quantity
        {
            get => quantity;
        }

        public virtual void GiveMedicine(int number)
        {
            Guard.WhenArgument(quantity - number, "Negative medicine quantity!").IsLessThan(0).Throw();
            quantity -= number;
        }

        public virtual void BuyMedicine(int number)
        {
            Guard.WhenArgument(number, "Cannot buy negative quantity!").IsLessThan(0).Throw();
            quantity += number;
        }

    }
}
