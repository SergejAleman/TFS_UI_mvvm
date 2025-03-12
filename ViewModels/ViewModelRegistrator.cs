using Microsoft.Extensions.DependencyInjection;

namespace TFS_UI_mvvm.ViewModels;

public static class ViewModelRegistrator
{
    public static IServiceCollection AddViewModel(this IServiceCollection services) => services
        .AddSingleton<WindowViewModels.NavigationViewModel>()
        .AddSingleton<UserControlViewModels.MainUserControlViewModel>()
        .AddSingleton<UserControlViewModels.UserControlA_ViewModel>()
        .AddSingleton<UserControlViewModels.UserControlB_ViewModel>()
        ;
}
