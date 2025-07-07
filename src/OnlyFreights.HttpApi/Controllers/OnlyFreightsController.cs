using OnlyFreights.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OnlyFreights.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OnlyFreightsController : AbpControllerBase
{
    protected OnlyFreightsController()
    {
        LocalizationResource = typeof(OnlyFreightsResource);
    }
}
