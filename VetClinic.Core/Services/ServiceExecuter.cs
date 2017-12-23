using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Core.Services.Contracts;

namespace VetClinic.Core.Services
{
    public class ServiceExecuter
    {
        private IService serviceToExecute;

        public ServiceExecuter(IService serviceToExecute)
        {
            this.serviceToExecute = serviceToExecute;
        }

        public void Execute()
        {
            int timeInSeconds = 0;

            switch (this.serviceToExecute.Id)
            {
                case "1": // Healing
                    timeInSeconds = 5;
                    Console.WriteLine($"Your pet is being healed. Please wait {timeInSeconds} seconds.");
                    // event 
                    return;

                case "2":  // Vaccination
                    timeInSeconds = 4;
                    Console.WriteLine($"Your pet is being vaccinated. Please wait {timeInSeconds} seconds.");
                    return;

                case "3": // Anti parasite treatment
                    timeInSeconds = 3;
                    Console.WriteLine($"Your pet is being treated against parasites. Please wait {timeInSeconds} seconds.");
                    return;

                case "4": // Grooming
                    timeInSeconds = 6;
                    Console.WriteLine($"Your pet is being groomed. Please wait {timeInSeconds} seconds.");
                    return;

                case "5": // Buy products

                    // TO DO !!
                    throw new NotImplementedException("Service BUY PRODUCTS is not implemented yet!");
                    return;

            }
        }
    }
}
