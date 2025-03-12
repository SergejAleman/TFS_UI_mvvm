using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.Views.WindowViews;
using TFS_UI_mvvm.Views.UserControlViews;

namespace TFS_UI_mvvm.Views;

public static class ViewRegistrator
{
    public static IServiceCollection AddView(this IServiceCollection services) => services
        .AddTransient<MainWindow>()
        .AddTransient<MainUserControl>()
        .AddTransient<UserControlA>()
        .AddTransient<UserControlB>()
        ;
}
