using TFS_UI_mvvm.Models;

namespace TFS_UI_mvvm.Services.Interfaces;

public interface IWorkItemService
{
    Task<List<WorkItemModel>> GetWorkItemsAsync();
}
