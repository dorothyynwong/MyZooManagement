using Microsoft.EntityFrameworkCore;
using ZooManagement;
using ZooManagement.Data;
using ZooManagement.Repositories;
using ZooManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZooManagementDbContext>(options =>
{
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.UseSqlite("Data Source=ZooManagement.db");
});

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();
builder.Services.AddTransient<IEnclosuresRepo, EnclosuresRepo>();
builder.Services.AddTransient<IAnimalService, AnimalService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ZooManagementDbContext>();
    context.Database.EnsureCreated();

    if (!context.Classifications.Any())
    {
        var classification = SampleClassification.GetClassifications();
        context.Classifications.AddRange(classification);
        context.SaveChanges();
    }
    if (!context.Species.Any())
    {
        var species = SampleSpecies.GetSpecies();
        context.Species.AddRange(species);
        context.SaveChanges();
    }
    if (!context.Enclosures.Any())
    {
        var enclosures = SampleEnclosures.GetEnclosures();
        context.Enclosures.AddRange(enclosures);
        context.SaveChanges();

        if (!context.Animals.Any())
        {
            int startIndex = 0;
            var enclosuresDB = context.Enclosures;
            foreach(var enclosure in enclosuresDB)
            {
                var animal = SampleAnimals.GetAnimals(startIndex, enclosure.NumberOfAnimals, enclosure.Id);
                context.Animals.AddRange(animal);
                context.SaveChanges();
                startIndex += enclosure.NumberOfAnimals;
            }
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();