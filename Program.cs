using Microsoft.EntityFrameworkCore;
using ZooManagement;
using ZooManagement.Data;
using ZooManagement.Repositories;

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
builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ZooManagementDbContext>();
    context.Database.EnsureCreated();
    if (!context.Animals.Any())
    {
        var animal = SampleAnimals.GetAnimals();
        context.Animals.AddRange(animal);
        context.SaveChanges();
    }
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