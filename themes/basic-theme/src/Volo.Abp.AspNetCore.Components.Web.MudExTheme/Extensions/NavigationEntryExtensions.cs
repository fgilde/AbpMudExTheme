namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Extensions;

internal static class NavigationEntryExtensions
{
    public static string FindIcon(this NavigationEntry entry)
    {
        if(!string.IsNullOrWhiteSpace(entry?.Icon))
            return entry.Icon;
        return entry?.Parent?.FindIcon();
    }
}