# ABP MudExTheme

This is a theme for ABP Framework using [MudBlazor](https://www.mudblazor.com) and [MudBlazor.Extensions](https://www.mudex.org).

The source for the theme is available under [/themes/basic-theme/src/](https://github.com/fgilde/AbpMudExTheme/tree/master/themes/basic-theme/src)

Also here in the repository you can find a sample application that uses this theme.

The sample application follows the structure of a typical ABP application created with ABP Studio


# Getting Started

To get started with the theme install the NuGet package in your ABP.Blazor.Client application.

Open your <App>BlazorClientModule.cs and ensure it depends on the `AbpAspNetCoreComponentsWebAssemblyMudExThemeModule`

```csharp
[DependsOn(
    ...
    ...
    typeof(AbpAspNetCoreComponentsWebAssemblyMudExThemeModule),
)]
public class OnlyFreightsBlazorClientModule : AbpModule
{
   ...

}
```