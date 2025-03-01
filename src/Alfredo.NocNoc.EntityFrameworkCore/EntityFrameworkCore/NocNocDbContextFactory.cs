using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Alfredo.NocNoc.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NocNocDbContextFactory : IDesignTimeDbContextFactory<NocNocDbContext>
{
    public NocNocDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        NocNocEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<NocNocDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new NocNocDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Alfredo.NocNoc.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
