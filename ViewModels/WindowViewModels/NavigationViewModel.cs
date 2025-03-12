using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.ViewModels.BaseClasses;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;
using TFS_UI_mvvm.Views.UserControlViews;

namespace TFS_UI_mvvm.ViewModels.WindowViewModels;

public class NavigationViewModel : BaseViewModel
{
    public string Title { get; set; } = "MyTitle";

    private object? currentView;

    public object? CurrentView
    {
        get => currentView;
        set
        {
            currentView = value;
            OnPropertyChanged();
        }
    }


    #region Commands
    public RelayCommand? SwitchToMainCommand { get; }
    public RelayCommand? SwitchToACommand { get; }
    public RelayCommand? SwitchToBCommand { get; }
    #endregion


    #region Constructor
    public NavigationViewModel()
    {
        CurrentView = new MainUserControlViewModel();
        
        SwitchToMainCommand = new RelayCommand(_ => CurrentView = new MainUserControlViewModel());
        SwitchToACommand = new RelayCommand(_ => CurrentView = new UserControlA_ViewModel());
        SwitchToBCommand = new RelayCommand(_ => CurrentView = new UserControlB_ViewModel());
    }
    #endregion
}
