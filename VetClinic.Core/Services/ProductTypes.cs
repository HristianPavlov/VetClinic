using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Core.Services
{
    class ProductTypes
    {
        public static Dictionary<string, decimal> products = new Dictionary<string, decimal>()
        {
            { "Medicine", 11.50m},
            { "Vitamins", 6.20m},
            { "Food", 3.80m},
        };
    }
}
