using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Models
{
    public static class DataBaseForOwners
    {
        public static Dictionary<string, IUser> data = new Dictionary<string, IUser>();

        // public  static List<Owner> data=new List<Owner>();
    }
}
