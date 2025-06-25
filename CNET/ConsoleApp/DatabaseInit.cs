using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ConsoleApp
{
    public class DatabaseInit
    {
        public static void DbInitFromJson()
        {
            var people = JsonDataset
            .LoadData(@"C:\PROJECTS\skoleni2025\github\net2025\data2024.json");

            Console.WriteLine($"načteno: {people.Count}");

            PeopleDbConxtext dbConxtext = new();

            var personCount = dbConxtext.Persons.Count();

            if (personCount == 0)
            {
                dbConxtext.Persons.AddRange(people);

                var changed = dbConxtext.SaveChanges();

                Console.WriteLine($"změnil v db: {changed} řádků");
            }
            else
            {
                Console.WriteLine("Databáze již obsahueje data");
            }

        }
    }
}
