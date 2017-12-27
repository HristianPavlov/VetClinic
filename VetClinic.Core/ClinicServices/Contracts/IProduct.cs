using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Core.ClinicServices.Contracts
{
    public interface IProduct
    {
        string Name { get;  }

        decimal Price { get; }
    }
}
