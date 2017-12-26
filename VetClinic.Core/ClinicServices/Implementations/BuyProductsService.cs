using System.Collections.Generic;
using VetClinic.Core.ClinicServices.Contracts;
using VetClinic.Core.ClinicServices.Implementations;

namespace VetClinic.Core.Services
{
    public class BuyProductService : Service, IService
    {
        private ICollection<IProduct> products;

        public BuyProductService()
            : base("Buy products")
        {
            this.products = new List<IProduct>();
        }

        public void ChooseProducts()
        {
            // TODO

            //foreach (var item in Product.products)
            //{

            //}

            base.Price = 0.0m;
        }
    }
}

