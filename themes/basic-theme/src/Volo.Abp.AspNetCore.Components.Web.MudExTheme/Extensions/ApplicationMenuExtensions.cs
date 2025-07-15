using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Extensions;

public static class ApplicationMenuExtensions
{
    public static HashSet<NavigationEntry> ToNavEntryList(this ApplicationMenu menu)
    {
        if (menu?.Items is not { Count: > 0 })
        {
            return new HashSet<NavigationEntry>();
        }


        return menu.Items.Select(item => MenuItemToNavEntry(item, null)).ToHashSet();
    }



    private static NavigationEntry MenuItemToNavEntry(ApplicationMenuItem menuItem, NavigationEntry parent)
    {
        var entry = new NavigationEntry
        {
            Text = menuItem.DisplayName ?? menuItem.Name,
            Icon = menuItem.Icon,
            Href = menuItem.Url?.TrimStart('/', '~'),
            Target = menuItem.Target,
            Parent = parent,
            Children = menuItem.Items.Select(child => MenuItemToNavEntry(child, null)).ToHashSet()
        };

        if(string.IsNullOrWhiteSpace(entry.Href) && (menuItem.Items == null || !menuItem.Items.Any()))
            entry.Href = "/";

        return entry;
    }
}
