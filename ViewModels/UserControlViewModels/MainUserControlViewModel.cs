using System.Collections.ObjectModel;
using TFS_UI_mvvm.Models;
using TFS_UI_mvvm.Services.Interfaces;
using TFS_UI_mvvm.ViewModels.BaseClasses;

namespace TFS_UI_mvvm.ViewModels.UserControlViewModels;

public class MainUserControlViewModel : BaseViewModel
{
    private readonly IWorkItemService workItemService;
    private ObservableCollection<WorkItemModel>? workItems;

    public ObservableCollection<WorkItemModel>? WorkItems
    {
        get => workItems;
        set
        {
            workItems = value;
            OnPropertyChanged();
        }
    }

    public MainUserControlViewModel(IWorkItemService workItemService)
    {
        this.workItemService = workItemService;
        LoadWorkItems();
    }


    private async void LoadWorkItems()
    {
        var items = await workItemService.GetAllWorkItemsAsync("SELECT [System.Id], [System.Title], [System.State] FROM WorkItems WHERE [System.TeamProject] = 'TL' AND [System.WorkItemType] = 'Test Case' ORDER BY [System.WorkItemType]");
        WorkItems = new ObservableCollection<WorkItemModel>(items);
    }
}
