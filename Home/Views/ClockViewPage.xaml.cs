using CommunityToolkit.Mvvm.DependencyInjection;

using Home.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Home.Views
{
    public sealed partial class ClockViewPage : Page
    {
        public ClockViewViewModel ViewModel { get; }

        public ClockViewPage()
        {
            ViewModel = Ioc.Default.GetService<ClockViewViewModel>();
            InitializeComponent();
        }
    }
}
