using Alfredo.NocNoc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Alfredo.NocNoc.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NocNocController : AbpControllerBase
{
    protected NocNocController()
    {
        LocalizationResource = typeof(NocNocResource);
    }
}
