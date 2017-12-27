using Bytes2you.Validation;
using VetClinic.Core.ClinicServices.Contracts;

namespace VetClinic.Core.ClinicServices.Implementations
{
    public class Purchase
    {
        private readonly IProduct product;

        private readonly int quantity;

        public Purchase(IProduct product, int quantity)
        {
            Guard.WhenArgument(quantity, "Quantity must be positive!").IsLessThan(0).Throw();
            this.product = product;
            this.quantity = quantity;
        }

        public IProduct Product { get; }

        public int Quantity { get; }
    }
}
