using VetClinic.Core.Services;
using VetClinic.Data.Models;

namespace VetClinic
{
    public class Startup
    {
        static void Main()
        {
            var pesho = new Owner("Pesho", "Peshev", "09678676");
            pesho.PrintPets();

            var clinicServices = new ClinicServices();
            clinicServices.AddServices(new Service("Surgery", 1000));
            clinicServices.AddServices(new Service("Vaccination", 50));
            System.Console.WriteLine(clinicServices.ListAllServices());

        }
    }
}
