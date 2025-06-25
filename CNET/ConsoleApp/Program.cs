
using DataAccess;

var people = JsonDataset
    .LoadData(@"C:\PROJECTS\skoleni2025\github\net2025\data2024.json");

Console.WriteLine($"načteno: {people.Count}");