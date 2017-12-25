using System;
using System.Linq;
using System.Text;
using VetClinic.Commands.Contracts;
using VetClinic.Commands.Implementations;
using VetClinic.Data.Common.Enums;
using VetClinic.Data.Contracts;
using VetClinic.Data.Models;
using VetClinic.Data.Models.Abstractions;

namespace VetClinic
{
    public sealed class Engine : IEngine
    {
        private const string SeparatorForConst = "====";
        private const string UserRegister = "RegisterUser ==== will give you the option to add a new Owner to the database";
        private const string AnimalAdd = "AddAnimal ==== will give you the option to add a new animal to an existing Owner";
        private const string AnimalRemove = "RemoveAnimal ==== will give you the option to remove the animal from an Owners data";
        private const string PetsPrint = "PrintPets ==== will print the information about the Owner's collection of pets";



        private const string END = "END " + SeparatorForConst + " will close the program";
        private const string InvalidCommand = "Invalid command!  {0}";


        private const string OwnerAddedSuccessfully = "{0} added successfully to the database with Id = {1}!";
        private const string AnimalAddedSuccessfully = "{0} named {1} with Id {2} added successfully to Owner {3} with Id {4}!";
        private const string AnimalRemovedSuccessfully = "{0} named {1} with Id {2} removed successfully from Owner with Id {3}!";


        private static readonly IEngine SingleInstance = new Engine();

        //private IDealershipFactory factory;
        //private ICollection<IUser> users;
        //private IUser loggedUser;

        private Engine()
        {
            //this.factory = new DealershipFactory();
            //this.users = new List<IUser>();
            //this.loggedUser = null;
        }

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            PrintOptions();

            string currentLine = Console.ReadLine().Trim();
            while (!currentLine.Equals("END"))
            {

                var commandResult = this.ProcessCommands(currentLine);

                this.PrintReports(commandResult);
                PrintOptions();
                currentLine = Console.ReadLine().Trim();
            }
        }

        private void PrintOptions()
        {
            Console.WriteLine(UserRegister);
            Console.WriteLine(AnimalAdd);
            Console.WriteLine(AnimalRemove);
            Console.WriteLine(PetsPrint);





            Console.WriteLine(END);




        }

        public void Reset()
        {
            //this.factory = new DealershipFactory();
            //this.users = new List<IUser>();
            //this.loggedUser = null;
            //var commands = new List<ICommand>();
            //var commandResult = new List<string>();
            //this.PrintReports(commandResult);
        }

        private ICommand ReadCommands(string line)
        {
            var command = new Command(line);

            //var currentLine = Console.ReadLine();

            //while (!string.IsNullOrEmpty(currentLine))
            //{
            //    var currentCommand = new Command(currentLine);
            //    commands.Add(currentCommand);

            //    currentLine = Console.ReadLine();
            //}

            return command;
        }

        private string ProcessCommands(string command)
        {
            var report = "";


            try
            {
                report = this.ProcessSingleCommand(command);
                //reports.Add(report);
            }
            catch (Exception ex)
            {
                report = ex.Message;
            }


            return report;
        }

        private void PrintReports(string report)
        {
            var output = new StringBuilder();

            //foreach (var report in reports)
            //{
            output.AppendLine(report);
            output.AppendLine(new string('#', 20));
            //}

            Console.Write(output.ToString());
        }


        private string ProcessSingleCommand(string command)
        {



            switch (command)
            {
               // case "RegisterUser":
                  //  return RegisterUser();


                case "AddAnimal":
                    Console.Write("Owner Id: ");
                    string id = Console.ReadLine();
                    // Console.WriteLine();
                    if (!CheckForID(id))
                    {
                        throw new ArgumentException("There is no such Id in the database");
                    }
                    Console.WriteLine("Which kind of animal would you like to add:");
                    foreach (var item in Enum.GetValues(typeof(AnimalType)))
                    {
                        Console.WriteLine(item);
                    }
                    AnimalType animal = (AnimalType)Enum.Parse(typeof(AnimalType), Console.ReadLine());
                    return AddAnimal(animal, id);


                case "RemoveAnimal":
                    Console.Write("Owner Id: ");
                    id = Console.ReadLine();
                    if (!CheckForID(id))
                    {
                        throw new ArgumentException("There is no such Id in the database");
                    }

                    Console.Write("Animal Id: ");
                    string idAnimal = Console.ReadLine();

                    return RemoveAnimal(idAnimal, id);

                case "PrintPets":
                    Console.Write("Owner Id: ");
                    id = Console.ReadLine();
                    if (!CheckForID(id))
                    {
                        throw new ArgumentException("There is no such Id in the database");
                    }

                    // Console.Write("Animal Id: ");
                    // string idAnimal = Console.ReadLine();
                    DataBaseForOwners.data[id].ListAllPets();
                    return string.Empty;




                default:
                    return string.Format(InvalidCommand, command);
            }
        }



        private string RemoveAnimal(string idAnimal, string id)
        {

            IAnimal animalToRemove = DataBaseForOwners.data[id]
                .Pets
                .FirstOrDefault(x => x.Id == idAnimal);
            if (animalToRemove == default(IAnimal))
            {
                throw new ArgumentException("There is no such Id in the database");
            }
            DataBaseForOwners.data[id].RemovePet(animalToRemove);


            return string.Format(AnimalRemovedSuccessfully, animalToRemove.Type, animalToRemove.Name, animalToRemove.Id, id);
        }

        private bool CheckForID(string id)
        {
            // int number = int.Parse(id.Substring(1));
            if (DataBaseForOwners.data.ContainsKey(id))
            {
                return true;
            }

            return false;

        }

        private string AddAnimal(AnimalType type, string id)
        {
            Console.Write("name: ");
            var name = Console.ReadLine();
            Console.WriteLine("gender(male/female): ");
            Console.WriteLine("age: ");
            int age = int.Parse(Console.ReadLine());

            AnimalGenderType gender = (AnimalGenderType)Enum.Parse(typeof(AnimalGenderType), Console.ReadLine().ToLower());

            Animal x = null;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Implement fill info method for each animal
            if (type == AnimalType.Dog)
            {
                Console.Write("breed: ");
                string breed = Console.ReadLine();
                x = new Dog(name, gender, breed, age);
            }
            else if (type == AnimalType.Cat)
            {
                x = new Cat(name, gender, age);
            }
            else if (type == AnimalType.Hamster)
            {           
                x = new Hamster(name, gender, age);
            }

            DataBaseForOwners.data[id].AddPet(x);
            IUser y = DataBaseForOwners.data[id];

            return string.Format(AnimalAddedSuccessfully, type.ToString(), name, x.Id, y.FirstName, y.Id);

        }

        //private string RegisterUser()
        //{
        //    string id = "O" + (User.gettingStaticID() + 1);
        //    Console.Write("first name: ");
        //    var firstName = Console.ReadLine();
        //    Console.Write("last name: ");
        //    var lastName = Console.ReadLine();
        //    Console.Write("Phone number: ");
        //    var phoneNumber = Console.ReadLine();
        //    Console.Write("Email: ");
        //    var email = Console.ReadLine();

        //    DataBaseForOwners.data.Add(id, new User(firstName, lastName, phoneNumber, email));

        //    return string.Format(OwnerAddedSuccessfully, firstName, id);
        //}

    }
}