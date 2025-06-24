using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Car
    {
        private readonly int id;
        private string _regNumber;

        public int Id { get; set; } = 0;

        public string RegistrationNumber 
        {
            get 
            {
                return _regNumber.ToUpper();
            }

            set
            {
                if(value.Length > 9) 
                {
                    Console.WriteLine("ERROR - SPZ TOO LONG");
                }

                _regNumber = value.Substring(0,9);
            }
        } 

        public string Brand { get; } = "Skoda";

        public override string ToString()
         => $"Car {Id} RegNum: {RegistrationNumber} Brand:{Brand}";
        
        public bool ChangeRegNumber(string newRegNumber)
        {
            RegistrationNumber = newRegNumber;

            // dalši logika

            return true;
        }
        


    }
}
