﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlyFreights.Data;
using Volo.Abp.DependencyInjection;

namespace OnlyFreights.EntityFrameworkCore;

public class EntityFrameworkCoreOnlyFreightsDbSchemaMigrator
    : IOnlyFreightsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOnlyFreightsDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OnlyFreightsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OnlyFreightsDbContext>()
            .Database
            .MigrateAsync();
    }
}
