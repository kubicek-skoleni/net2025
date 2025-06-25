using System.Net.Http.Json;
using ConsoleApp;
using Model;

Console.WriteLine("Starting..");

try
{
    DatabaseInit.DbInitFromJson();
} catch(Exception ex)
{ Console.WriteLine(ex.ToString()); }



//HttpClient client = new();
//client.BaseAddress = new Uri("https://localhost:7194");

//int id = 0;

//while (true)
//{
//    Console.Write("Input Person ID: ");
//    var consoleInput = Console.ReadLine(); // get input from user

//    if (consoleInput == "Q")
//        break;

//    try
//    {
//        id = int.Parse(consoleInput); // parse user input (string) to integer
//    }
//    catch(Exception ex)
//    {

//        Console.WriteLine($"Invalid input! {ex.Message}");
//        continue;
//    }

//    var person = await client.GetFromJsonAsync<Person>($"/person/{id}");
//    Console.WriteLine($"Person with ID {id}: {person.FirstName} {person.LastName}");
//}