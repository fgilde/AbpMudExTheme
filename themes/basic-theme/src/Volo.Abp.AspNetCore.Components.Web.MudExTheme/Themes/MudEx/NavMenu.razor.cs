using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor.Extensions.Core.Enums;
using Nextended.Core.Extensions;
using Nextended.Core.Types;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme.Extensions;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;
using Volo.Abp.AspNetCore.Components.Web.Security;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Themes.MudEx;

public partial class NavMenu : IDisposable
{
    private NavigationEntry _selectedNavEntry;
    private TreeViewExpandBehaviour _expandBehaviour;
    private TreeViewMode _viewMode = TreeViewMode.Default;
    
    [Inject] protected IMenuManager MenuManager { get; set; }
    [Inject] protected IThemeManager ThemeManager { get; set; }
    

    [Inject]
    protected ApplicationConfigurationChangedService ApplicationConfigurationChangedService { get; set; }

    protected ApplicationMenu Menu { get; set; }

    [Parameter] public bool IsMini { get; set; }

    [Parameter] public bool ShowUserCard { get; set; } = true;

    [Parameter] public bool ShowApplicationLogo { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await UpdateEntries();
        ApplicationConfigurationChangedService.Changed += ApplicationConfigurationChanged;
    }

    private async Task UpdateEntries()
    {
        Menu = await MenuManager.GetMainMenuAsync();
        Entries = Menu.ToNavEntryList();
    }

    private async void ApplicationConfigurationChanged()
    {
        await UpdateEntries();
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        ApplicationConfigurationChangedService.Changed -= ApplicationConfigurationChanged;
    }

    protected override Task OnParametersSetAsync()
    {
        ExpandToCurrentUrl();
        return base.OnParametersSetAsync();
    }



    public NavigationEntry SelectedNavEntry
    {
        get => _selectedNavEntry;
        set
        {
            if (_selectedNavEntry != value)
            {
                _selectedNavEntry = value;
                if (HasAction(value))
                {
                    try
                    {
                        NavigationManager.NavigateTo(value.Href);
                    }
                    catch
                    { }
                }
            }
        }
    }

    [Parameter]
    public TreeViewMode ViewMode
    {
        get => _viewMode;
        set
        {
            if (_viewMode == value)
                return;
            _viewMode = value;
            InvokeAsync(StateHasChanged);
        }
    }


    [Parameter] public HashSet<NavigationEntry>? Entries { get; set; } = null;

    [Parameter]
    public TreeViewExpandBehaviour ExpandBehaviour
    {
        get => _expandBehaviour;
        set
        {
            if (value != _expandBehaviour)
            {
                _expandBehaviour = value;
                InvokeAsync(StateHasChanged);
            }
        }
    }


    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            NavigationManager.LocationChanged += (s, e) => ExpandToCurrentUrl();
        }

        return base.OnAfterRenderAsync(firstRender);
    }
    

    private void ExpandToCurrentUrl()
    {
        var current = SelectedNavEntry;
        if(current == null)
            return;
        var url = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        SelectedNavEntry = FindEntriesForUrl(url)?.FirstOrDefault();
        if (SelectedNavEntry != null && SelectedNavEntry != current)
            InvokeAsync(StateHasChanged);
    }

    public IEnumerable<NavigationEntry> FindEntriesForUrl(string url = null)
    {
        url = (url ?? NavigationManager.ToBaseRelativePath(NavigationManager.Uri));
        if (string.IsNullOrEmpty(url)) return [];
        url = Nextended.Core.Extensions.StringExtensions.EnsureStartsWith(url, "/").ToLower();
        return Entries.Find(e => !string.IsNullOrWhiteSpace(e.Href) && Nextended.Core.Extensions.StringExtensions.EnsureStartsWith(e.Href,"/").ToLower() == url);
    }



    private bool HasAction(NavigationEntry entry)
    {
        return !string.IsNullOrWhiteSpace(entry?.Href);
    }

    public string Locale(string s)
    {
        return _localizer != null ? _localizer[s ?? ""] : s ?? "";
    }

    private HashSet<NavigationEntry> GetEntries()
    {
        if (IsMini)
            return Entries.Recursive(e => e.Children).Where(HasAction).ToHashSet();
        return Entries;
    }
}
