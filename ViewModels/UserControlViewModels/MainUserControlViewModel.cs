using System.Collections.ObjectModel;
using System.Windows.Input;
using TFS_UI_mvvm.Models;
using TFS_UI_mvvm.Services.Interfaces;
using TFS_UI_mvvm.ViewModels.BaseClasses;

namespace TFS_UI_mvvm.ViewModels.UserControlViewModels;

public class MainUserControlViewModel : BaseViewModel
{
    private readonly IWorkItemService workItemService;
    private ObservableCollection<WorkItemModel>? workItems;
    private WorkItemModel? selectedWorkItem;



    public string SummaryText => SelectedWorkItem?.Description ?? "No Description";

    public string ItemsCount => $"Items quantity: {WorkItems?.Count ?? 0}";


    public ICommand? LoadWorkItemsCommand { get; }

    public ObservableCollection<WorkItemModel>? WorkItems
    {
        get => workItems;
        set
        {
            workItems = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ItemsCount));
        }
    }


    public WorkItemModel? SelectedWorkItem
    {
        get => selectedWorkItem;
        set
        {
            selectedWorkItem = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SummaryText));
        }
    }


    public MainUserControlViewModel(IWorkItemService workItemService)
    {
        this.workItemService = workItemService;
        LoadWorkItemsCommand = new RelayCommand(async _ => await LoadWorkItems());
    }


    private async Task LoadWorkItems()
    {
        var items = await workItemService.GetAllWorkItemsAsync("SELECT [System.Id], [System.Title], [System.Description] FROM WorkItems WHERE [System.TeamProject] = 'TL' AND [System.WorkItemType] = 'Test Case' ORDER BY [System.WorkItemType]");
        WorkItems = new ObservableCollection<WorkItemModel>(items);
    }
}
