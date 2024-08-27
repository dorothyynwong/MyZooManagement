using Microsoft.EntityFrameworkCore;
using ZooManagement;
using ZooManagement.Data;
using ZooManagement.Repositories;
using ZooManagement.Services;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Web;

string currentDirectory = System.IO.Directory.GetCurrentDirectory();
var config = new LoggingConfiguration();
var todayDate = DateTime.Now.ToString("yyyy-MM-dd");
var target = new FileTarget { FileName = @$"{currentDirectory}\Logs\ZooManagement\{todayDate}.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, target));
LogManager.Configuration = config;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); 
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

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
builder.Services.AddTransient<ISpeciesRepo, SpeciesRepo>();
builder.Services.AddTransient<IEnclosuresRepo, EnclosuresRepo>();
builder.Services.AddTransient<IZooKeepersRepo, ZooKeepersRepo>();
builder.Services.AddTransient<IAnimalService, AnimalService>();


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