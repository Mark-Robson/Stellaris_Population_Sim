using System;
using dataTypes.Calendar;

namespace Stellaris_Population_Sim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DateTime start = new DateTime(2000,1,1);
            DateTime end = new DateTime(2200,1,1);
            Calendar c = new Calendar(start,end);

            Console.WriteLine(c.startDate);
        }
    }
}
