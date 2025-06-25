using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PeopleDbConxtext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello from API");

app.MapGet("/person/count",
            (PeopleDbConxtext db) => db.Persons.Count());

app.MapGet("/person/{id}", (int id, PeopleDbConxtext db)
    => db.Persons
    .Include(x => x.Address)
    .Include(x => x.Contracts)
    .Where(person => person.Id == id).First()
);

app.Map("/contract/count", (PeopleDbConxtext db)
    => db.Contracts.Count());

app.MapGet("/city/top20", (PeopleDbConxtext db) =>
        db.Persons
        .Include(x => x.Address)
        .Where(x => x.Address != null)
        .GroupBy(x => x.Address.City)
        .ToList()
        .OrderByDescending(g => g.Count())
        .Take(20)
        .Select(x => new { City = x.Key, Count = x.Count() })
        );

// hledání osob podle emailu (část emailu, - obsahuje)

app.MapGet("/person/email/{email}", (string email, PeopleDbConxtext db)
    => db.Persons
    .Where(x => x.Email.ToLower().Contains(email.ToLower()))
    .Take(100)
    );

app.Run();


