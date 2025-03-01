using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Alfredo.NocNoc.Data;

/* This is used if database provider does't define
 * INocNocDbSchemaMigrator implementation.
 */
public class NullNocNocDbSchemaMigrator : INocNocDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
