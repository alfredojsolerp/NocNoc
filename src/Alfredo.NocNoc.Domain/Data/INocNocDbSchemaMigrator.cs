using System.Threading.Tasks;

namespace Alfredo.NocNoc.Data;

public interface INocNocDbSchemaMigrator
{
    Task MigrateAsync();
}
