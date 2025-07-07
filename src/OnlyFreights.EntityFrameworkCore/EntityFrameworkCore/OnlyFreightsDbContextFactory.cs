﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnlyFreights.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OnlyFreightsDbContextFactory : IDesignTimeDbContextFactory<OnlyFreightsDbContext>
{
    public OnlyFreightsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        OnlyFreightsEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<OnlyFreightsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new OnlyFreightsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OnlyFreights.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
