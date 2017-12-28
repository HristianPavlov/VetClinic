using System;
using System.Collections.Generic;
using System.Text;
using VetClinic.Data.Contracts;

namespace VetClinic.Core
{
    public class CashRegister
    {
        private static decimal money;

        private static ICollection<IService> performedServices;

        private CashRegister()
        {
            money = 0.00m;
            performedServices = new List<IService>();
        }

        public static decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount must be positive!");
                }
                money = value;
            }
        }

        public void AddServicesToList(ICollection<IService> servicesToAdd)
        {
            foreach (var service in servicesToAdd)
            {
                performedServices.Add(service);
            }
        }

        public void PrintDailyReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Performed services for the day:");

            foreach (var item in performedServices)
            {
                sb.AppendLine($"  {item.Name} - ${item.Price}");
            }

            sb.AppendLine($"TOTAL: ${Math.Round(money, 2)}");
        }
    }
}

