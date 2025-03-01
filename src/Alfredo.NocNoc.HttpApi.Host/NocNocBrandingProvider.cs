using Microsoft.Extensions.Localization;
using Alfredo.NocNoc.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Alfredo.NocNoc;

[Dependency(ReplaceServices = true)]
public class NocNocBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<NocNocResource> _localizer;

    public NocNocBrandingProvider(IStringLocalizer<NocNocResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
