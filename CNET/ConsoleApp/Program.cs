
var people = new[]
{
     new { Name = "Jan", City = "Praha", Age = 25 },
     new { Name = "Marie", City = "Brno", Age = 30 },
     new { Name = "Petr", City = "Praha", Age = 35 },
     new { Name = "Eva", City = "Brno", Age = 28 },
     new { Name = "Tomáš", City = "Ostrava", Age = 32 },
     new { Name = "Lucie", City = "Praha", Age = 27 }
};

//var result = people.GroupBy(x => x.City);

//foreach (var city_people in result)
//{
//    Console.WriteLine($"Key: {city_people.Key}");

//    foreach(var person in city_people)
//    {
//        Console.WriteLine(person.Name);
//    }

//    Console.WriteLine();
//}

// Seskup podle věkové kategorie (pod 30 a 30+)
// kolik v každé skupině
// vypiš lidi dle skupin

var byAgeCategory = people.GroupBy(x => x.Age < 30 ? "Pod 30" : "30+");

foreach(var ageGroup in  byAgeCategory)
{
    var group_name = ageGroup.Key;
    var group_count = ageGroup.Count();

    Console.WriteLine($"skupina {group_name}, počet lidí: {group_count}");

    foreach(var person in ageGroup)
    {
        Console.WriteLine($"{person.Name} - {person.Age}");
    }
}