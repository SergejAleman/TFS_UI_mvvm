using Microsoft.Extensions.DependencyInjection;

namespace TFS_UI_mvvm.ViewModels;

public static class ViewModelRegistrator
{
    public static IServiceCollection AddViewModel(this IServiceCollection services) => services
        .AddSingleton<WindowViewModels.MainWindowViewModel>()
        .AddSingleton<UserControlViewModels.UserControlA_ViewModel>()
        .AddTransient<UserControlViewModels.UserControlB_ViewModel>()
        ;
}
