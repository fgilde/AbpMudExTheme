using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Components.Web.BasicTheme;

public static class ApplicationMenuExtensions
{
    public static HashSet<NavigationEntry> ToNavEntryList(this ApplicationMenu menu)
    {
        var navEntries = new HashSet<NavigationEntry>();
        if (menu?.Items is not { Count: > 0 })
        {
            return navEntries;
        }


        foreach (var entry in menu.Items.Select(item => MenuItemToNavEntry(item, null)))
        {
            navEntries.Add(entry);
        }

        return navEntries;
    }

    private static HashSet<NavigationEntry> ProcessMenuItems(IEnumerable<ApplicationMenuItem> items, NavigationEntry parent)
    {
        var entries = new HashSet<NavigationEntry>();
        foreach (var item in items)
        {
            var entry = MenuItemToNavEntry(item, parent);
            entries.Add(entry);
        }
        return entries;
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
        };

        Console.WriteLine(entry.Text +"=" + entry.Href);

        if (menuItem.Items is not { Count: > 0 })
            return entry;
        
        entry.Children = new HashSet<NavigationEntry>();
        foreach (var childEntry in menuItem.Items.Select(child => MenuItemToNavEntry(child, entry)))
        {
            entry.Children.Add(childEntry);
        }

        return entry;
    }
}
