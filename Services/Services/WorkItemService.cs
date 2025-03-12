using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using TFS_UI_mvvm.Models;
using TFS_UI_mvvm.Services.Interfaces;

namespace TFS_UI_mvvm.Services.Services;

public class WorkItemService : IWorkItemService
{
    private readonly string tfsUrl = "https://automatix:8081/tfs/TLCollection/";
    private readonly string teamProject = "TL";
    //private readonly string? query;


    public async Task<List<WorkItemModel>> GetAllWorkItemsAsync(string query)
    {
        VssConnection connection = new VssConnection(new Uri(tfsUrl), new VssCredentials());
        WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

        Wiql wiql = new Wiql { Query = query };
        WorkItemQueryResult queryResult = await witClient.QueryByWiqlAsync(wiql, teamProject);

        var workItemModels = new List<WorkItemModel>();

        if (queryResult.WorkItems.Any())
        {
            var ids = queryResult.WorkItems.Select(wi => wi.Id).ToArray();
            var fields = new[] { "System.Id", "System.Title", "System.State" };
            var items = await witClient.GetWorkItemsAsync(ids, fields);
            foreach (var item in items)
            {
                if (item.Id == null)
                    throw new InvalidOperationException("Work item ID is null");

                workItemModels.Add(new WorkItemModel(
                    item.Id.Value,
                    item.Fields["System.Title"]?.ToString() ?? "No Title",
                    item.Fields["System.State"]?.ToString() ?? "Unknown"
                    ));
            }
        }
        return workItemModels;
    }
}