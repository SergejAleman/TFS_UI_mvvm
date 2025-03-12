using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.Services.Interfaces;
using TFS_UI_mvvm.Services.Services;


namespace TFS_UI_mvvm.Services;

public static class ServiceRegistrator
{
    public static IServiceCollection AddService(this IServiceCollection services) => services
        .AddSingleton<IWorkItemService, WorkItemService>()
        ;
}
