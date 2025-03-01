using Alfredo.NocNoc.Samples;
using Xunit;

namespace Alfredo.NocNoc.EntityFrameworkCore.Applications;

[Collection(NocNocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<NocNocEntityFrameworkCoreTestModule>
{

}
