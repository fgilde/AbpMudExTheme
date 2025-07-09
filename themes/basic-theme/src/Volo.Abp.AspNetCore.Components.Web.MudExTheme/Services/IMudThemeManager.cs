using System.Collections.Generic;
using System.Threading.Tasks;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;

public interface IMudThemeManager 
{
    Task<IDictionary<string, ClientTheme>> ThemesAsync();
    Task<ClientTheme> GetByNameAsync(string name);
    Task<ClientTheme> GetDefaultThemeAsync();
    ClientTheme CurrentTheme { get;  }
}