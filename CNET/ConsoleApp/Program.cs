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
//var cities = db.Persons
//    .Include(x => x.Address)
//    .Where(x => x.Address != null)
//    .GroupBy(x => x.Address.City)
//    .ToList()
//    .OrderByDescending(g => g.Count())
//    .Take(20)
//    ;

//foreach (var city in cities)
//{
//    Console.WriteLine($"město: {city.Key}, počet lidí: {city.Count()}");
//}

//3. kolik je v systému smluv (Contracts)

var pocet_smluv = db.Contracts.Count();

Console.WriteLine($"počet smluv: {pocet_smluv}");

// 4. kolik osob bez smluv (pokud nějaké)
var pocetBezSmluv = db.Persons.Include(x => x.Contracts)
    .Where(osoba => osoba.Contracts == null)
    .Count();

Console.WriteLine($"bez smluv: {pocetBezSmluv}");

// 5. kolik osob bez adresy
var pocetBezAdresy = db.Persons.Include(x => x.Address)
    .Where(osoba => osoba.Address == null)
    .Count();

Console.WriteLine($"bez adresy: {pocetBezAdresy}");

var addrCount = db.Addresses.Count();
Console.WriteLine($"addrCount: {addrCount}");

var personCount = db.Persons.Count();
Console.WriteLine($"person count: {personCount}");
