using Volo.Abp.Modularity;

namespace Alfredo.NocNoc;

[DependsOn(
    typeof(NocNocApplicationModule),
    typeof(NocNocDomainTestModule)
)]
public class NocNocApplicationTestModule : AbpModule
{

}
