using OnlyFreights.Localization;
using Volo.Abp.Application.Services;

namespace OnlyFreights;

/* Inherit your application services from this class.
 */
public abstract class OnlyFreightsAppService : ApplicationService
{
    protected OnlyFreightsAppService()
    {
        LocalizationResource = typeof(OnlyFreightsResource);
    }
}
