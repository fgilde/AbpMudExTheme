using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;
using Volo.Abp.DependencyInjection;

namespace OnlyFreights.Blazor.Services;


[Dependency(ReplaceServices = true)]
public class OnlyFreightThemeManager : IMudThemeManager, ISingletonDependency
{
    private readonly IJSRuntime _jsRuntime;

    public OnlyFreightThemeManager(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public Task<ClientTheme> GetDefaultThemeAsync()
    {
        return Task.FromResult(ClientThemes.LuckyGreen);
    }

    public ClientTheme CurrentTheme => ClientThemes.LastUsedTheme;

    public Task<IDictionary<string, ClientTheme>> ThemesAsync()
    {
        return Task.FromResult(ClientThemes.All);
    }

    public async Task<ClientTheme> GetByNameAsync(string name)
    {
        return (await ThemesAsync()).FirstOrDefault(p => p.Key == name).Value;
    }
}