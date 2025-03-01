using Alfredo.NocNoc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Alfredo.NocNoc.Permissions;

public class NocNocPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NocNocPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(NocNocPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NocNocResource>(name);
    }
}
