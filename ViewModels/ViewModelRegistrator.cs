using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.ViewModels.WindowViewModels;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;

namespace TFS_UI_mvvm.ViewModels;

public static class ViewModelRegistrator
{
    public static IServiceCollection AddViewModel(this IServiceCollection services) => services
        .AddSingleton<NavigationViewModel>()
        .AddSingleton<MainUserControlViewModel>()
        .AddSingleton<UserControlA_ViewModel>()
        .AddSingleton<UserControlB_ViewModel>()
        ;
}
