using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Serilog;
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
            //ViewModel에 등록해야한다. 
            Ioc.Default.ConfigureServices 
                (new ServiceCollection()
                    //.AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    //.AddSingleton<ILoggingService, DebugLoggingService>()
                    .AddSingleton<ProductViewModel>()
                    //.AddTransient<ProductViewModel>()
                    .AddSingleton<Page1ViewModel>()
                    .AddSingleton<Page2ViewModel>()
                    .AddSingleton<Page3ViewModel>()
                    .AddSingleton<OpenFileDialogViewModel>()
                    
                    .AddSingleton<MainWindow>()
                    .AddLogging(builder =>
                    {
                         var logger = new LoggerConfiguration()
                         .MinimumLevel.Debug()
                         .WriteTo.Console()
                         .CreateLogger();

                         builder.AddSerilog(logger);
                    })
                    /*
                    .AddDbContext<EmployeeDbContext>(options =>
                    {
                        options.UseSqlite("Data Source = Employee.db");
                    });
                    */

                    .BuildServiceProvider()
                );

            this.InitializeComponent();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {

            var mainWindow = Ioc.Default.GetService<MainWindow>();
            mainWindow.Show();
        }
        private async void Application_Exit(object sender, ExitEventArgs e)
        {
 
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
