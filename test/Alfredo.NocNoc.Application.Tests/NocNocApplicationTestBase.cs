using Volo.Abp.Modularity;

namespace Alfredo.NocNoc;

public abstract class NocNocApplicationTestBase<TStartupModule> : NocNocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
