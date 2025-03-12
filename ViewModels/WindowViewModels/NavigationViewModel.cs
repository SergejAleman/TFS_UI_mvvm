using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.Services.Interfaces;
using TFS_UI_mvvm.ViewModels.BaseClasses;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;
using TFS_UI_mvvm.Views.UserControlViews;

namespace TFS_UI_mvvm.ViewModels.WindowViewModels;

public class NavigationViewModel : BaseViewModel
{
    private readonly IServiceProvider serviceProvider;

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
    public NavigationViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        CurrentView = serviceProvider.GetRequiredService<MainUserControl>();

        SwitchToMainCommand = new RelayCommand(_ => CurrentView = serviceProvider.GetRequiredService<MainUserControl>());
        SwitchToACommand = new RelayCommand(_ => CurrentView = new UserControlA_ViewModel());
        SwitchToBCommand = new RelayCommand(_ => CurrentView = new UserControlB_ViewModel());
    }
    #endregion
}
