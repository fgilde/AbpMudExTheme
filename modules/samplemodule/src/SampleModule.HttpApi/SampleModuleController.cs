using SampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleModule;

public abstract class SampleModuleController : AbpControllerBase
{
    protected SampleModuleController()
    {
        LocalizationResource = typeof(SampleModuleResource);
    }
}
