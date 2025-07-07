using SampleModule.Localization;
using Volo.Abp.Application.Services;

namespace SampleModule;

public abstract class SampleModuleAppService : ApplicationService
{
    protected SampleModuleAppService()
    {
        LocalizationResource = typeof(SampleModuleResource);
        ObjectMapperContext = typeof(SampleModuleApplicationModule);
    }
}
