using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFS_UI_mvvm.ViewModels;
using TFS_UI_mvvm.Views;
using System.Windows;
using TFS_UI_mvvm.Services;
using TFS_UI_mvvm.ViewModels.WindowViewModels;
using TFS_UI_mvvm.Views.WindowViews;

namespace TFS_UI_mvvm;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) => services
                .AddView()
                .AddViewModel()
                .AddService()
            )
            .Build();
    }


    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();
        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
        mainWindow.Show();
        base.OnStartup(e);
    }


    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        AppHost?.Dispose();
        AppHost = null;

        base.OnExit(e);
    }
}
