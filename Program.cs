using ZooManagement.Data;

namespace ZooManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooManagementDbContext>();
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}