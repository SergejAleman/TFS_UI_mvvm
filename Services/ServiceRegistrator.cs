using Microsoft.Extensions.DependencyInjection;
using Microsoft.TeamFoundation.Core.WebApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFS_UI_mvvm.Services.Interfaces;
using TFS_UI_mvvm.Services.Services;
using TFS_UI_mvvm.Views.MainWindow;

namespace TFS_UI_mvvm.Services;

public static class ServiceRegistrator
{
    public static IServiceCollection AddService(this IServiceCollection services) => services
        .AddSingleton<IWorkItemService>(new WorkItemService())
        ;
}
