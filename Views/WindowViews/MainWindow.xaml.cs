using System.Windows;
using TFS_UI_mvvm.ViewModels.WindowViewModels;

namespace TFS_UI_mvvm.Views.WindowViews;

public partial class MainWindow : Window
{
    public MainWindow(NavigationViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
