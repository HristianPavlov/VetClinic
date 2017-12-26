namespace VetClinic
{
    using VetClinic.Commands.Implementations;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Implemetations;

    public class Startup
    {
        static void Main()
        {
            //var c = new Cat("asss", AnimalGenderType.male, -1);
            //Console.WriteLine(c.Id);

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

            //Engine.Instance.Start();
            var personFactory = new PersonFactory();
            var userDb = new UserRepository();
            var command = new UserCommand(personFactory, userDb);

            var engine = new EngineExample(userDb, command);
            engine.Start();

        }
    }
}
