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

app.Run();


