using System;
using VetClinic.Core.ClinicServices.Contracts;


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

            switch (this.serviceToExecute.Name)
            {
                case "Healing":
                    timeInSeconds = 5;
                    Console.WriteLine($"Your pet is being healed. Please wait {timeInSeconds} seconds.");
                    // TODO event 
                    return;

                case "Vaccination":
                    timeInSeconds = 4;
                    Console.WriteLine($"Your pet is being vaccinated. Please wait {timeInSeconds} seconds.");
                    // TODO event 
                    return;

                case "Anti parasite treatment":
                    timeInSeconds = 3;
                    Console.WriteLine($"Your pet is being treated against parasites. Please wait {timeInSeconds} seconds.");
                    // TODO event 
                    return;

                case "Grooming":
                    timeInSeconds = 6;
                    Console.WriteLine($"Your pet is being groomed. Please wait {timeInSeconds} seconds.");
                    // TODO event 
                    return;

                case "Buy products":

                    // TODO !!
                    throw new NotImplementedException("Service BUY PRODUCTS is not implemented yet!");
            }
        }
    }
}

