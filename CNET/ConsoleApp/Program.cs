using DataAccess;
using Microsoft.EntityFrameworkCore;

// připojte se k db

var db = new PeopleDbConxtext();

// 1. města a kolik v každěm městě osob a vypište do konzole
// řešení bez vazby
//var cities = db.Addresses.GroupBy(x => x.City);

// řešení s vazbou
//var cities = db.Persons
//    .Include(x => x.Address)
//    .Where(x => x.Address != null)
//    .GroupBy(x => x.Address.City);

// 2. upravte na pouze 20 nejčastěších měst
var cities = db.Persons
    .Include(x => x.Address)
    .Where(x => x.Address != null)
    .GroupBy(x => x.Address.City)
    .ToList()
    .OrderByDescending(g => g.Count())
    .Take(20)
    ;

foreach (var city in cities)
{
    Console.WriteLine($"město: {city.Key}, počet lidí: {city.Count()}");
}

//3. kolik je v systému smluv (Contracts)


