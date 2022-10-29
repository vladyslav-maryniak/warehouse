using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Windows;
using Warehouse.DesktopApplication.Services;

namespace Warehouse.DesktopApplication
{
    public partial class App : Application
    {
        private static readonly Uri warehouseApiUri = new("https://localhost:7238");
        private static readonly IHost appHost =
            Host.CreateDefaultBuilder()
                .ConfigureServices(Configure)
                .Build();

        public static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddRefitClient<IEmployeeService>()
                .ConfigureHttpClient(httpClient => httpClient.BaseAddress = warehouseApiUri);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await appHost.StartAsync();

            var startupForm = appHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await appHost.StopAsync();

            base.OnExit(e);
        }
    }
}
