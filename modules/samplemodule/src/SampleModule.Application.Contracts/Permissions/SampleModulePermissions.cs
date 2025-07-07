using Volo.Abp.Reflection;

namespace SampleModule.Permissions;

public class SampleModulePermissions
{
    public const string GroupName = "SampleModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SampleModulePermissions));
    }
}
