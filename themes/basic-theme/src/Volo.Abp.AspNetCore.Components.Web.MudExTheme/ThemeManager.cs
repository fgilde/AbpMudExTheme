using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme
{
    public class ThemeManager: IThemeManager
    {
        private readonly IJSRuntime _jsRuntime;

        public ThemeManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<ClientTheme> GetDefaultThemeAsync()
        {
            return Task.FromResult(ClientThemes.DefaultTheme);
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
}