using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DayOfWeek
    {
        static string ReturnDay(int DayofTheWeek)
        {
            switch (DayofTheWeek)
            {
                case 1: return "Monday";
                case 2: return "Tuesday";
                case 3: return "Wednesday";
                case 4: return "Thursday";
                case 5: return "Friday";
                case 6: return "Saturday";
                case 7:
                    return "Sunday";
               default: return "Unknown";
            }
        }
    }
}
