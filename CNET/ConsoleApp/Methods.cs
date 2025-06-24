using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Methods
    {
        static int Age(DateTime dob)
        {
            return DateTime.Now.Year - dob.Year;

            //Console.WriteLine("xxx");
        }

        static void Print(string input, int maxlenght)
         => Console.WriteLine(input);
        

        static string GetDayOfWeek_SwitchExpression(int dayNumber) => dayNumber switch
        {
            1 => "Pondělí",
            2 => "Úterý",
            3 => "Středa",
            4 => "Čtvrtek",
            5 => "Pátek",
            6 => "Sobota",
            7 => "Neděle",
            _ => "Neplatné číslo dne"
        };


        enum DenVTydnu
        {
            [Description("Pondělí")]
            Pondeli = 1,
         
            Utery = 2,
            
            Streda = 3,
            
            Ctvrtek = 4,
            Patek = 5,
            Sobota = 6,
            Nedele = 7
        }

        static string GetDayOfWeek_Enum(int dayNumber)
        {
            if (Enum.IsDefined(typeof(DenVTydnu), dayNumber))
            {
                var den = (DenVTydnu)dayNumber;
                return den switch
                {
                    DenVTydnu.Pondeli => "Pondělí",
                    DenVTydnu.Utery => "Úterý",
                    DenVTydnu.Streda => "Středa",
                    DenVTydnu.Ctvrtek => "Čtvrtek",
                    DenVTydnu.Patek => "Pátek",
                    DenVTydnu.Sobota => "Sobota",
                    DenVTydnu.Nedele => "Neděle",
                    _ => "Neplatné číslo dne"
                };
            }
            return "Neplatné číslo dne";
        }
    }
}
