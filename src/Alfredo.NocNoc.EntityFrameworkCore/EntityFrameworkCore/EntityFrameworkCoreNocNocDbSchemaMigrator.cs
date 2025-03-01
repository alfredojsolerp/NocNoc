using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Alfredo.NocNoc.Data;
using Volo.Abp.DependencyInjection;

namespace Alfredo.NocNoc.EntityFrameworkCore;

public class EntityFrameworkCoreNocNocDbSchemaMigrator
    : INocNocDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNocNocDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the NocNocDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NocNocDbContext>()
            .Database
            .MigrateAsync();
    }
}
