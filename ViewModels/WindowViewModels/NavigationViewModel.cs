using Microsoft.Extensions.DependencyInjection;
using TFS_UI_mvvm.ViewModels.BaseClasses;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;
using TFS_UI_mvvm.Views.UserControlViews;

namespace TFS_UI_mvvm.ViewModels.WindowViewModels;

public class NavigationViewModel : BaseViewModel
{
    public string Title { get; set; } = "MyTitle";
    //private readonly IServiceProvider serviceProvider;

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
    public RelayCommand? SwitchToACommand { get; }
    public RelayCommand? SwitchToBCommand { get; }
    #endregion


    #region Constructors
    ////Empty constructor for design time
    //public MainWindowViewModel()
    //{
    //    if (!IsInDesignMode())
    //        throw new InvalidOperationException("ServiceProvider is required at runtime");
    //}



    public NavigationViewModel()
    {
        //this.serviceProvider = serviceProvider;

        CurrentView = new MainUserControlViewModel();

        SwitchToACommand = new RelayCommand(_ => CurrentView = new UserControlA_ViewModel());
        SwitchToBCommand = new RelayCommand(_ => CurrentView = new UserControlB_ViewModel());




        //SwitchToACommand = new RelayCommand(_ => ShowUserControlA());
        //SwitchToBCommand = new RelayCommand(_ => ShowUserControlB());

        //ShowUserControlA();
    }
    #endregion


    #region Methods
    //private void ShowUserControlA()
    //{
    //    //if (serviceProvider == null) throw new InvalidOperationException("ServiceProvider is required at runtime");
    //    var view = serviceProvider.GetRequiredService<UserControlA>();
    //    view.DataContext = serviceProvider.GetRequiredService<UserControlA_ViewModel>();
    //    CurrentView = view;
    //}


    //private void ShowUserControlB()
    //{
    //    //if (serviceProvider == null) throw new InvalidOperationException("ServiceProvider is required at runtime");
    //    var view = serviceProvider.GetRequiredService<UserControlB>();
    //    view.DataContext = serviceProvider.GetRequiredService<UserControlB_ViewModel>();
    //    CurrentView = view;
    //}

    ////For design time
    //private bool IsInDesignMode()
    //{
    //    return System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
    //} 
    #endregion
}
