using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VetClinic.Core.ClinicServices.Implementations
{
    public static class Timer
    {
        private static int timeInSeconds = 5;
        
        public static void PrintServiceResult(object sender, EventArgs args)
        {
            Stopwatch interval = new Stopwatch();
            interval.Start();

            if (interval.ElapsedMilliseconds == timeInSeconds * 1000)
            {
                Console.WriteLine("Your pet is ready to go!");
            }

        }
    }
}
