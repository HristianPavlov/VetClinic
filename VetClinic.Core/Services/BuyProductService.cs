using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Core.Services.Contracts;

namespace VetClinic.Core.Services
{
    public class BuyProductService : Service, IService
    {
        private ICollection<Product> products;

        public BuyProductService()
            : base("Buy products")
        {
            this.products = new List<Product>();
        }

        public void ChooseProducts()
        {
            //foreach (var item in Product.products)
            //{

            //}

            base.Price = 0;
        }
    }
}
