using Microsoft.UI.Xaml.Controls;

using NodeForWinUI.ViewModels;

namespace NodeForWinUI.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
