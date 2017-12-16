using VetClinic.Data.Models;

namespace VetClinic
{
    public class Startup
    {
        static void Main()
        {
            var pesho = new Owner("Pesho", "Peshev", "09678676");
            pesho.PrintPets();
        }
    }
}
