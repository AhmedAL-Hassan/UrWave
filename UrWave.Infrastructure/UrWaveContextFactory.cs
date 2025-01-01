namespace UrWave.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

public class UrWaveContextFactory : IDesignTimeDbContextFactory<UrWaveContext>
{
    public UrWaveContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "UrWave.Api"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<UrWaveContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new UrWaveContext(optionsBuilder.Options);
    }
}