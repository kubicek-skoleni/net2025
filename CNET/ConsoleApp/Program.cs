using DataAccess;
using Microsoft.EntityFrameworkCore;

// připojte se k db

// 1. města a kolik v každěm městě osob a vypište do konzole

var db = new PeopleDbConxtext();


// řešení bez vazby
//var cities = db.Addresses.GroupBy(x => x.City);

// řešení s vazbou
var cities = db.Persons
    .Include(x => x.Address)
    .Where(x => x.Address != null)
    .GroupBy(x => x.Address.City);

foreach (var city in cities)
{
    Console.WriteLine($"město: {city.Key}, počet lidí: {city.Count()}");
}


