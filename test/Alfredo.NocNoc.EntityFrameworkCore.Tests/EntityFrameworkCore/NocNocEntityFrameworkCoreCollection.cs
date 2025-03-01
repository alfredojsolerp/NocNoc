using Xunit;

namespace Alfredo.NocNoc.EntityFrameworkCore;

[CollectionDefinition(NocNocTestConsts.CollectionDefinitionName)]
public class NocNocEntityFrameworkCoreCollection : ICollectionFixture<NocNocEntityFrameworkCoreFixture>
{

}
