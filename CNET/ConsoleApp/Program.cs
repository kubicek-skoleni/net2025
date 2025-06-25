
Console.WriteLine("Starting..");

HttpClient client = new();


var homeText = await client.GetStringAsync("https://localhost:7194");

Console.WriteLine($"result: {homeText}");