using Alfredo.NocNoc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Alfredo.NocNoc.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NocNocEntityFrameworkCoreModule),
    typeof(NocNocApplicationContractsModule)
)]
public class NocNocDbMigratorModule : AbpModule
{
}
