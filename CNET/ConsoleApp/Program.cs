using System.Net.Http.Json;
using Model;

Console.WriteLine("Starting..");

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7194");

int id = 0;

while (true)
{
    Console.Write("Input Person ID: ");
    var consoleInput = Console.ReadLine(); // get input from user

    if (consoleInput == "Q")
        break;

    try
    {
        id = int.Parse(consoleInput); // parse user input (string) to integer
    }
    catch (Exception)
    {

        Console.WriteLine("Invalid input!");
        continue;
    }

    var person = await client.GetFromJsonAsync<Person>($"/person/{id}");
    Console.WriteLine($"Person with ID {id}: {person.FirstName} {person.LastName}");
}