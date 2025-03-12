using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TFS_UI_mvvm.ViewModels.BaseClasses;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;
using TFS_UI_mvvm.Views.UserControlViews;

namespace TFS_UI_mvvm.ViewModels.WindowViewModels;

public class MainWindowViewModel : BaseViewModel
{
    public string Title { get; set; } = "MyTitle";

    private readonly IServiceProvider? serviceProvider;

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


    //Empty constructor for design time
    public MainWindowViewModel()
    {
        if (!IsInDesignMode())
            throw new InvalidOperationException("ServiceProvider is required at runtime");
    }


    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        SwitchToACommand = new RelayCommand(_ => ShowUserControlA());
        SwitchToBCommand = new RelayCommand(_ => ShowUserControlB());

        ShowUserControlA();
    }


    private void ShowUserControlA()
    {
        if (serviceProvider == null) throw new InvalidOperationException("ServiceProvider is required at runtime");
        var view = serviceProvider.GetRequiredService<UserControlA>();
        view.DataContext = serviceProvider.GetRequiredService<UserControlA_ViewModel>();
        CurrentView = view;
    }


    private void ShowUserControlB()
    {
        if (serviceProvider == null) throw new InvalidOperationException("ServiceProvider is required at runtime");
        var view = serviceProvider.GetRequiredService<UserControlB>();
        view.DataContext = serviceProvider.GetRequiredService<UserControlB_ViewModel>();
        CurrentView = view;
    }

    //For design time
    private bool IsInDesignMode()
    {
        return System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
    }
}
