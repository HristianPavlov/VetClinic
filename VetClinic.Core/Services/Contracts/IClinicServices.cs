namespace VetClinic.Core.Services.Contracts
{
    using System.Collections.Generic;

    public interface IClinicServices
    {
        //ICollection<IService> Services { get; }

        //string ListAllServices();  
        // ^ Не може да се декларира като статичен метод в интерфейса. Трябва да е статичен за да се извиква през Engine ChooseService.


        void AddServices(IService service);

        void RemoveServices(IService service);

        void FindById(string id);

        bool ContainsService(string id);
    }
}
