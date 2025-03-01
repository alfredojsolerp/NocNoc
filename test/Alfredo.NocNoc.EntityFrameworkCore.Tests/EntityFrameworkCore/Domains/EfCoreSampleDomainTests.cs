using Alfredo.NocNoc.Samples;
using Xunit;

namespace Alfredo.NocNoc.EntityFrameworkCore.Domains;

[Collection(NocNocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<NocNocEntityFrameworkCoreTestModule>
{

}
