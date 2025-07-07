using SampleModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SampleModule.Permissions;

public class SampleModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SampleModulePermissions.GroupName, L("Permission:SampleModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SampleModuleResource>(name);
    }
}
