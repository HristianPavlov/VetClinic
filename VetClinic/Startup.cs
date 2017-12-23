using VetClinic.Core.Services;
using VetClinic.Data.Models;
using VetClinic.Data.Models.Abstractions;

using VetClinic.Data.Common.Enums;

namespace VetClinic
{
    public class Startup
    {
        static void Main()
        {

            Engine.Instance.Start();

            //var pesho = new Owner("Pesho", "Peshev", "09678676");
            //pesho.PrintPets();
            //Animal kat = new Dog("adas",GenderType.Male,37,"Ulichna");
            //pesho.AddPet(kat);
            //Animal a = new Hamster("adas",GenderType.Male);
            //pesho.AddPet(a);

            //Animal ww = new Cat("adas",GenderType.Male,37);
            //pesho.AddPet(ww);
            //pesho.PrintPets();

            //var clinicServices = new ClinicServices();
            //clinicServices.AddServices(new Service("Surgery", 1000));
            //clinicServices.AddServices(new Service("Vaccination", 50));
            //System.Console.WriteLine(clinicServices.ListAllServices());

        }
    }
}
