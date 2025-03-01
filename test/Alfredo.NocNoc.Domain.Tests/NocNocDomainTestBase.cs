using Volo.Abp.Modularity;

namespace Alfredo.NocNoc;

/* Inherit from this class for your domain layer tests. */
public abstract class NocNocDomainTestBase<TStartupModule> : NocNocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
