using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using GulkortetNETFramework.Repositories;
using GulkortetNETFramework.Repositories.Interfaces;
using GulkortetNETFramework.Services;
using GulkortetNETFramework.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GulkortetNETFramework
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bygger min container
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;


            Application.Run(ServiceProvider.GetService<GuldkortetServer>());
        }

        private static IServiceProvider ServiceProvider { get; set; }


        // Skapar en container så att jag kan göra DI 
        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Lägger till services i containern
                    services.AddTransient<GuldkortetServer>();
                    services.AddScoped<UserContext>();
                    services.AddScoped<CardContext>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<ICardRepository, CardRepository>();
                    services.AddScoped<ITcpServer, TcpServer>();
                    services.AddScoped<IIncomingDataValidator, IncomingDataValidator>();

                });
        }
    }
}
