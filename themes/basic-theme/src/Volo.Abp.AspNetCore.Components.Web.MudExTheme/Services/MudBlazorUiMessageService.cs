using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Extensions.Components;
using MudBlazor.Extensions.Core;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;

[Dependency(ReplaceServices = true)]
public class MudBlazorUiMessageService : IUiMessageService, IScopedDependency
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<AbpUiResource> _localizer;

    public MudBlazorUiMessageService(IDialogService dialogService, IStringLocalizer<AbpUiResource> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }

    public Task<bool> Confirm(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        return _dialogService.ShowConfirmationDialogAsync(title, message, _localizer["Yes"], _localizer["No"], icon: Icons.Material.Filled.QuestionMark);
    }

    public Task Error(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        DialogParameters parameters = new DialogParameters()
        {
            {nameof(MudExMessageDialog.Message), message},
            {nameof(MudExMessageDialog.Buttons), MudExDialogResultAction.Ok(_localizer["Ok"])},
            {nameof(MudExMessageDialog.Icon), Icons.Material.Filled.Error},
            {nameof(MudExMessageDialog.IconColor), MudExColor.Error},
        };
        return _dialogService.ShowInformationAsync(title, parameters);
    }

    public Task Info(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        DialogParameters parameters = new DialogParameters()
        {
            {nameof(MudExMessageDialog.Message), message},
            {nameof(MudExMessageDialog.Buttons), MudExDialogResultAction.Ok(_localizer["Ok"])},
            {nameof(MudExMessageDialog.Icon), Icons.Material.Filled.Info},
            {nameof(MudExMessageDialog.IconColor), MudExColor.Info},
        };
        return _dialogService.ShowInformationAsync(title, parameters);
    }

    public Task Success(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        DialogParameters parameters = new DialogParameters()
        {
            {nameof(MudExMessageDialog.Message), message},
            {nameof(MudExMessageDialog.Buttons), MudExDialogResultAction.Ok(_localizer["Ok"])},
            {nameof(MudExMessageDialog.Icon), Icons.Material.Filled.Check},
            {nameof(MudExMessageDialog.IconColor), MudExColor.Success},
        };
        return _dialogService.ShowInformationAsync(title, parameters);
    }

    public Task Warn(string message, string title = null, Action<UiMessageOptions> options = null)
    {
        DialogParameters parameters = new DialogParameters()
        {
            {nameof(MudExMessageDialog.Message), message},
            {nameof(MudExMessageDialog.Buttons), MudExDialogResultAction.Ok(_localizer["Ok"])},
            {nameof(MudExMessageDialog.Icon), Icons.Material.Filled.Warning},
            {nameof(MudExMessageDialog.IconColor), MudExColor.Warning},
        };
        return _dialogService.ShowInformationAsync(title, parameters);
    }

}