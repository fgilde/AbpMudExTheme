using OnlyFreights.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace OnlyFreights.Permissions;

public class OnlyFreightsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OnlyFreightsPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(OnlyFreightsPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(OnlyFreightsPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(OnlyFreightsPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(OnlyFreightsPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OnlyFreightsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OnlyFreightsResource>(name);
    }
}
