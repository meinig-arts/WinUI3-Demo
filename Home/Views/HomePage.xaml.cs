using CommunityToolkit.Mvvm.DependencyInjection;

using Home.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Home.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; }

        public HomePage()
        {
            ViewModel = Ioc.Default.GetService<HomeViewModel>();
            InitializeComponent();
        }
    }
}
