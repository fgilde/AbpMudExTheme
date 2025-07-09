using Microsoft.Extensions.Localization;
using OnlyFreights.Localization;
using Microsoft.Extensions.Localization;
using OnlyFreights.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OnlyFreights.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class OnlyFreightsBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OnlyFreightsResource> _localizer;

    public OnlyFreightsBrandingProvider(IStringLocalizer<OnlyFreightsResource> localizer)
    {
        _localizer = localizer;
    }

    public override string? LogoUrl =>
        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAcCAMAAABF0y+mAAAAS1BMVEVHcEw2ADw4ADw4ADw4ADw2ADw4ADw4ADwzADs1ADwzADs4ADw4ADw4ADw4ADw4ADw4ADw3ADzwAFPxAFPpAFLpAFLpAFL9AFXpAFLXn8/hAAAAGXRSTlMAVY20ykjA/yE3EvPYp2flL3hEP9P/wyqxiSoaLgAAAUdJREFUeAFl0gdyxCAQBdEPSDRJgJzvf1LPsnLcrppKTxHQT86HbQt+12OR70L6S7lg1dbq4uMXJXoh7lq5DRjlG6th1vRtjM1PzQGUX6jZuGpJAapW3dCdwPC9+wp0heu9ezTcjLJUirRXTAdMw3EYwqYSrg9tkBJsUmLhUOZqqtIUoOi84/rRXsoJaIeU16sXDh1Q9PSsBF7VBoOx0AtOvby+vslTdbCp2dSFvUB6erXeM+hkKDJ+4/PC/RcOotod9fb6+qGDYRMNm02Vv1Dv73JwquINggFl3tEF5wIMOUiGpzJ4jTtimQk2GSapguZ5w9mgdWlAMRySOhzSDbVygNOhzcka0BfuwfvAsrPK61YC09SudxLL+s+r/TpSM7YWziIFDH8rPmmVPFbWd2lg1XAcsWK1ot/1ynfD6X/Zx2EQ/dSVPgEKiBLijOzVgAAAAABJRU5ErkJggg==";

    public override string AppName => _localizer["AppName"];
}
