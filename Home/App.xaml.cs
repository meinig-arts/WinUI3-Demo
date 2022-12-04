using CommunityToolkit.Mvvm.DependencyInjection;

using Home.Activation;
using Home.Contracts.Services;
using Home.Helpers;
using Home.Services;
using Home.ViewModels;
using Home.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using System.IO;
using System.Reflection;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace Home
{
    public partial class App : Application
    {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var appDir = System.AppDomain.CurrentDomain.BaseDirectory;
            Assembly libraryAssembly = Assembly.LoadFile(appDir + "/Library.dll");
            var types = libraryAssembly.GetTypes();

            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices()
        {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services

            // Views and ViewModels
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomePage>();
            services.AddTransient<ClockViewViewModel>();
            services.AddTransient<ClockViewPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            return services.BuildServiceProvider();
        }
    }
}
