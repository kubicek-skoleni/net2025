
using System.Net.Http.Json;
using Model;

Console.WriteLine("Starting..");

Console.WriteLine("Zadej ID osoby:");
string line = Console.ReadLine();
int id = 0;

try
{
    id = int.Parse(line);
}
catch(Exception ex)
{
    Console.WriteLine("Nepodařilo se mi převést ID na číslo");
    return;
}


HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7194");
Person person = await client.GetFromJsonAsync<Person>($"/person/{id}");


Console.WriteLine($"person id {id}: {person.FirstName} {person.LastName}");