using VetClinic.Data.Common.Enums;

namespace VetClinic.Data.Contracts
{
    public interface IAnimal
    {
        

         AnimalType Type
        {
            get;

        }


         string Name
        {
            get ;
            
        }

       

         AnimalGenderType Gender
        {
            get ;
            
        }

      

     

        string Id { get; }



        

         
        
         
        

    }
}