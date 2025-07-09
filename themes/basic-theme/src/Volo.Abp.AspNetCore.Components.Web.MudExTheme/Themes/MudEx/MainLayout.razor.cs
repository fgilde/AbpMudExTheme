using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Themes.MudEx;

public partial class MainLayout : IDisposable
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    internal bool IsDrawerOpen;
    internal MainNavMenuDrawer NavMenuDrawer;
    private ClientTheme _theme;

    private bool IsCollapseShown { get; set; }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        _theme = _themeManager?.CurrentTheme ?? await _themeManager?.GetDefaultThemeAsync();
        await base.OnInitializedAsync();
    }

    private void ToggleCollapse()
    {
        IsCollapseShown = !IsCollapseShown;
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        IsCollapseShown = false;
        InvokeAsync(StateHasChanged);
    }
    private void DrawerToggle()
    {
        IsDrawerOpen = !IsDrawerOpen;
        InvokeAsync(StateHasChanged);
    }

    private void PinnedChanged()
    {
        InvokeAsync(StateHasChanged).ContinueWith(task =>
        {
            DrawerToggle(); DrawerToggle();  // 2 calls to Ensure refresh and old state
        });
    }
}
