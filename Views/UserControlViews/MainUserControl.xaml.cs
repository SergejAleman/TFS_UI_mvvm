using System.Windows.Controls;
using TFS_UI_mvvm.ViewModels.UserControlViewModels;

namespace TFS_UI_mvvm.Views.UserControlViews;

public partial class MainUserControl : UserControl
{
    public MainUserControl(MainUserControlViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}