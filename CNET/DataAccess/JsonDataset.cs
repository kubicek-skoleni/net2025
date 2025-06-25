using System.Text.Json;
using Model;

namespace DataAccess
{
    public class JsonDataset
    {
        public static List<Person> LoadData(string path)
        {
            var fileContent = File.ReadAllText(path);
            var people = JsonSerializer
                        .Deserialize<List<Person>>(fileContent);

            return people;
        }
    }
}
