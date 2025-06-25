using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace ConsoleApp
{
    public class DatabaseInit
    {
        public static void DbInitFromJson()
        {
            List<Person> people;
            string file = @"C:\PROJECTS\skoleni2025\github\net2025\_data2024.json";
            
            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Nenašel jsem dataset.");
            }

            try
            {
                people = JsonDataset
                .LoadData(file);

                Console.WriteLine($"načteno: {people.Count}");

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Nenašel jsem soubor na: {file}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
                return;
            }
            

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
