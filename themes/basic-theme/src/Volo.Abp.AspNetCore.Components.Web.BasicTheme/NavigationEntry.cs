using System;
using MudBlazor;
using Nextended.Core.Types;

namespace Volo.Abp.AspNetCore.Components.Web.BasicTheme;

public class NavigationEntry : Hierarchical<NavigationEntry>
{
    protected bool Equals(NavigationEntry other)
    {
        return Text == other.Text && Href == other.Href;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((NavigationEntry)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Text, Href);
    }

    public NavigationEntry()
    {}

    public NavigationEntry(string text = "", string icon = "", string href = "", string target = "") : this()
    {
        Icon = icon;
        Text = text;
        Href = href;
        Target = target;
    }

    public string Text { get; set; }
    public string Icon { get; set; }
    public string Href { get; set; }
    public string Target { get; set; }
    public bool? Bold { get; set; }
    public Color GetIconColor() => Color.Default;
    public override string ToString()
    {
        return Text;
    }
}