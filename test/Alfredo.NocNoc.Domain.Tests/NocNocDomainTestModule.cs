using Volo.Abp.Modularity;

namespace Alfredo.NocNoc;

[DependsOn(
    typeof(NocNocDomainModule),
    typeof(NocNocTestBaseModule)
)]
public class NocNocDomainTestModule : AbpModule
{

}
