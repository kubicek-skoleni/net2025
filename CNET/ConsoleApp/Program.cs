var cars = new[]
{
    new { Brand = "Škoda", Model = "Octavia", Year = 2020, PricePerDay = 800, Available = true },
    new { Brand = "Škoda", Model = "Fabia", Year = 2021, PricePerDay = 600, Available = true },
    new { Brand = "VW", Model = "Golf", Year = 2019, PricePerDay = 900, Available = false },
    new { Brand = "VW", Model = "Passat", Year = 2020, PricePerDay = 1200, Available = true },
    new { Brand = "BMW", Model = "3 Series", Year = 2021, PricePerDay = 1500, Available = true },
    new { Brand = "BMW", Model = "X3", Year = 2020, PricePerDay = 2000, Available = false }
};

// 1. Počet aut podle značky
var carBrand = cars.GroupBy(x => x.Brand)
      .Select(g => new
      {
          Brand = g.Key,
          Count = g.Count(),
      });

foreach (var item in carBrand)
{
    Console.WriteLine($"Brand: {item.Brand}: {item.Count} ");
}

// 2. Dostupná auta seřazená podle ceny

var carAvailability = cars
    .Where(x => x.Available)
    .OrderBy(x => x.PricePerDay);

Console.WriteLine("\nDostupná auta podle ceny:");
foreach (var car in carAvailability)
{
    Console.WriteLine($"{car.Brand} {car.Model} - {car.PricePerDay} Kč");
}


// 3. Průměrná cena podle značky

var averagePrice = cars
    .GroupBy(x => x.Brand)
    .Select(g => new
    {
        Brand = g.Key,
        Price = g.Average(x => x.PricePerDay)
    });

Console.WriteLine("\nPrůměrná cena podle značky:");
foreach (var item in averagePrice)
{
    Console.WriteLine($"{item.Brand}: {item.Price} Kč");
}