using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Windows;
using WPF.Core.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Services = ConfigureServices();
            Ioc.Default.ConfigureServices 
                (new ServiceCollection()
                    //.AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    //.AddSingleton<ILoggingService, DebugLoggingService>()
                    .AddSingleton<ProductViewModel>()
                    .AddSingleton<Page1ViewModel>()
                    .AddSingleton<Page2ViewModel>()

                    .BuildServiceProvider()
                );

            this.InitializeComponent();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // ViewModel, View 등록 {
            services.AddTransient<ProductViewModel>();
            services.AddTransient<MainWindow>();

            services.AddTransient<Page1>();
            services.AddTransient<Page2>();

            // 어플리케이션 Context 등록
            //services.AddSingleton<IAppContext>(new AppContext());

            // 자원 서비스 등록
            //services.AddSingleton<IResourceService>(new ResourceService());

            return services.BuildServiceProvider();
        }
    }
    
}
