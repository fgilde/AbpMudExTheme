﻿using System.Collections.Generic;
using MudBlazor;
using MudBlazor.Extensions.Core.Enums;
using MudBlazor.Extensions.Helper;
using Nextended.Core.Extensions;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme;

public static class ClientThemes
{

    public static IDictionary<string, ClientTheme> All => new Dictionary<string, ClientTheme>
    {
        {nameof(DefaultTheme), DefaultTheme},
        {nameof(LuckyGreen), LuckyGreen},
        {nameof(CodeBlue), CodeBlue}
    };


    #region Default Typography and Layout

    private static Typography DefaultTypography => new()
    {
        Default = new DefaultTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },
        H1 = new H1Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "6rem",
            FontWeight = "300",
            LineHeight = "1.167",
            LetterSpacing = "-.01562em"
        },
        H2 = new H2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "3.75rem",
            FontWeight = "300",
            LineHeight = "1.2",
            LetterSpacing = "-.00833em"
        },
        H3 = new H3Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "3rem",
            FontWeight = "400",
            LineHeight = "1.167",
            LetterSpacing = "0"
        },
        H4 = new H4Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "2.125rem",
            FontWeight = "400",
            LineHeight = "1.235",
            LetterSpacing = ".00735em"
        },
        H5 = new H5Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1.5rem",
            FontWeight = "400",
            LineHeight = "1.334",
            LetterSpacing = "0"
        },
        H6 = new H6Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1.25rem",
            FontWeight = "400",
            LineHeight = "1.6",
            LetterSpacing = ".0075em"
        },
        Button = new ButtonTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.75",
            LetterSpacing = ".02857em"
        },
        Body1 = new Body1Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1rem",
            FontWeight = "400",
            LineHeight = "1.5",
            LetterSpacing = ".00938em"
        },
        Body2 = new Body2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },
        Caption = new CaptionTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".75rem",
            FontWeight = "400",
            LineHeight = "1.66",
            LetterSpacing = ".03333em"
        },
        Subtitle2 = new Subtitle2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.57",
            LetterSpacing = ".00714em"
        }
    };

    private static LayoutProperties GetDefaultLayoutProperties() => new()
    {
        DefaultBorderRadius = "3px", // default 3
        DrawerWidthLeft = "320px",
        DrawerWidthRight = "320px"
    };

    #endregion


    public static ClientTheme DefaultTheme = new ClientTheme()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#1E88E5",
            AppbarBackground = "#1E88E5",
            Background = Colors.Gray.Lighten5,
            DrawerBackground = "#FFF",
            DrawerText = "rgba(0,0,0, 0.7)",
            Success = "#007E33"
        },
        Typography = DefaultTypography,
        LayoutProperties = GetDefaultLayoutProperties()
    }.SetProperties(
            t => t.PaletteDark = t.PaletteLight.ToPaletteDark().SetProperties(p => p.AppbarBackground = "#373740")
        );


    public static ClientTheme LuckyGreen = new ClientTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#199b90",
            AppbarBackground = "#199b90",
            Background = Colors.Gray.Lighten5,
            DrawerBackground = "#FFF",
            DrawerText = "rgba(0,0,0, 0.7)",
            Success = "#19635d"
        },
        Typography = DefaultTypography,
        LayoutProperties = GetDefaultLayoutProperties()
    }.SetProperties(
        t => t.PaletteDark = t.PaletteLight.ToPaletteDark());


    public static ClientTheme CodeBlue = new ClientTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#0082bb",
            AppbarBackground = "#0082bb",
            Secondary = "#ff8300",
            Background = Colors.Gray.Lighten5,
            DrawerBackground = "#FFF",
            DrawerText = "rgba(0,0,0, 0.7)",
            Success = "#128a00",
            Warning = "#ffdd00",
            Error = "#df1642"
        },
        Typography = DefaultTypography,
        LayoutProperties = GetDefaultLayoutProperties()
    }.SetProperties(
        t => t.PaletteDark = t.PaletteLight.ToPaletteDark(),
        t => t.ShowUserCardInNavigation = false,
        t => t.ShowLogoInAppBar = false,
        t => t.ShowLogoInNavMenu = true,
        t => t.AppBarTitleBehaviour = AppBarTitleBehaviour.TitleOnly,
        t => t.MenuTogglePosition = MenuTogglePosition.Start,
        t => t.DrawerClipMode = DrawerClipMode.Never,
        t => t.DrawerVariant = DrawerVariant.Temporary,
        t => t.NavMenuExpandMode = TreeViewExpandBehaviour.SingleExpand);

    
    
    public static ClientTheme LastUsedTheme { get; set; }

}