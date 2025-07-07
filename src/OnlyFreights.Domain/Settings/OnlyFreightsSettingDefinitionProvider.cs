using Volo.Abp.Settings;

namespace OnlyFreights.Settings;

public class OnlyFreightsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OnlyFreightsSettings.MySetting1));
    }
}
