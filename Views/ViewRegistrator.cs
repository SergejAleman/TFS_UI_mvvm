using Microsoft.Extensions.DependencyInjection;

namespace TFS_UI_mvvm.Views;

public static class ViewRegistrator
{
    public static IServiceCollection AddView(this IServiceCollection services) => services
        .AddSingleton<MainWindow.MainWindow>()
        .AddTransient<UserControls.UserControlA>()
        .AddTransient<UserControls.UserControlB>()
        ;
}
