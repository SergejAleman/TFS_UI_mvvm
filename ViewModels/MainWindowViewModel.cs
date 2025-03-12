using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.ViewModels.BaseClasses;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;
using TFS_UI_mvvm.Views.UserControls;
using System.Windows.Controls;

namespace TFS_UI_mvvm.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    public string Title { get; set; } = "MyTitle";

    public RelayCommand? SwitchToACommand { get; }
    public RelayCommand? SwitchToBCommand { get; }

    private UserControl? currentView;

	public UserControl? CurrentView
    {
        get => currentView;
        set
        {
            currentView = value;
            OnPropertyChanged();
        }
    }

    private readonly IServiceProvider serviceProvider;


    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        SwitchToACommand = new RelayCommand(_ => ShowUserControlA());
        SwitchToBCommand = new RelayCommand(_ => ShowUserControlB());

        ShowUserControlA();
    }


    private void ShowUserControlA()
    {
        var view = serviceProvider.GetRequiredService<UserControlA>();
        view.DataContext = serviceProvider.GetRequiredService<UserControlA_ViewModel>();
        CurrentView = view;
    }


    private void ShowUserControlB()
    {
        var view = serviceProvider.GetRequiredService<UserControlB>();
        view.DataContext = serviceProvider.GetRequiredService<UserControlB_ViewModel>();
        CurrentView = view;
    }

}
