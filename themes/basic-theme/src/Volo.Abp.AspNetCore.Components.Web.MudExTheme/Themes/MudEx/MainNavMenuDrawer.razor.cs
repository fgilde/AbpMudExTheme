using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions.Core.Enums;
using MudBlazor.Extensions.Helper;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Themes.MudEx;

public partial class MainNavMenuDrawer
{
    private bool _pinned = true;
    
    private bool _singleExpand;

    public NavMenu Menu { get; private set; }

    [Inject]
    internal IMudThemeManager ThemeManager { get; set; }

    [CascadingParameter] 
    internal MainLayout Layout { get; set; }

    [CascadingParameter]
    internal ClaimsPrincipal User { get; set; }

    [Parameter]
    public EventCallback<bool> PinnedChanged { get; set; }

    [Parameter]
    public EventCallback<bool> SingleExpandChanged { get; set; }
    
    [Parameter]
    public bool Pinned
    {
        get => _pinned;
        set => UpdatePinned(value);
    }

    [Parameter]
    public bool SingleExpand
    {
        get => _singleExpand;
        set => UpdateSingleExpand(value);
    }

    public bool AllowSettingsChange => true; // Layout?.CurrentTheme is not {CanPinDrawer: false, CanChangeDrawerExpandMode: false};

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        //var preference = await _clientPreferenceManager.GetPreference();
        //Pinned = preference.IsDrawerPinned;
        //SingleExpand = preference.DrawerSingleExpand;
    }

    protected override async Task OnParametersSetAsync()
    {
        SetVariantAndClipMode();
        await base.OnParametersSetAsync();
    }

    private void SetVariantAndClipMode()
    {
        if (ThemeManager?.CurrentTheme?.CanPinDrawer ?? true)
        {
            Variant = Pinned ? DrawerVariant.Mini : DrawerVariant.Temporary;
            ClipMode = Pinned ? DrawerClipMode.Always : DrawerClipMode.Never;
        }
        else if(ThemeManager?.CurrentTheme != null)
        {
            Variant = ThemeManager.CurrentTheme.DrawerVariant;
            ClipMode = ThemeManager.CurrentTheme.DrawerClipMode;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ChildContent = DrawerContent();
    }

    private bool ShowLogoInMenu() => Open && (ThemeManager?.CurrentTheme?.ShowLogoInNavMenu ?? !Pinned);
    private bool ShowUserInMenu() => Open && (ThemeManager?.CurrentTheme?.ShowUserCardInNavigation ?? !Pinned);

    private TreeViewExpandBehaviour GetExpandMode() => TreeViewExpandBehaviour.Default;//Layout?.CurrentTheme?.CanChangeDrawerExpandMode == true ? SingleExpand ? TreeViewExpandBehaviour.SingleExpand : TreeViewExpandBehaviour.Default : Layout?.CurrentTheme?.NavMenuExpandMode ?? TreeViewExpandBehaviour.Default;

    private string SettingsContainerStyle()
    {
        return MudExStyleBuilder.Empty()
                .With("align-self", "flex-start")
                .WithMarginLeft("auto", !MiniAndClosed())
                .WithMarginLeft(-13, MiniAndClosed())
                .WithBorderBottomWidth(1)
                .WithBorderColor(Color.Secondary)
                .WithPadding(4, MiniAndClosed())
                .Build();
    }

    private bool MiniAndClosed() => !Open && Variant == DrawerVariant.Mini;

    private void Update<T>(T value, Action<T> s, EventCallback<T> toRaise)
    {
        s(value);
        toRaise.InvokeAsync(value);
        InvokeAsync(StateHasChanged);
        SavePreferences();
    }
    
    private void UpdateSingleExpand(bool value) => Update(value, b => _singleExpand = b, SingleExpandChanged);
    private void UpdatePinned(bool value)
    {
        if (!value && !Open)
        {
            Open = true;
            _popoverOpen = false;
        }

        Update(value, b => _pinned = b, PinnedChanged);
    }

    private void SavePreferences()
    {
        //_ = _clientPreferenceManager.SetPreference(p =>
        //{
        //    p.IsDrawerPinned = Pinned;
        //    p.DrawerSingleExpand = SingleExpand;
        //});
    }
}