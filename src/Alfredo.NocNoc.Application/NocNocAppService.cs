using Alfredo.NocNoc.Localization;
using Volo.Abp.Application.Services;

namespace Alfredo.NocNoc;

public abstract class NocNocAppService : ApplicationService
{
	protected NocNocAppService()
	{
		LocalizationResource = typeof(NocNocResource);
	}
}
