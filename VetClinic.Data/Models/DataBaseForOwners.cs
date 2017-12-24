using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Models
{
    public static class DataBaseForOwners
    {
        public static Dictionary<string, IPetOwner> data = new Dictionary<string, IPetOwner>();

        // public  static List<Owner> data=new List<Owner>();
    }
}
