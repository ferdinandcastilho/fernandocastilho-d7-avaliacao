using LoginScreenApp.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using LoginScreenApp.DataContext.Repositories;

namespace LoginScreenApp;

public partial class App : Application
{
    private static IHost MainHost => Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddDbContext<AppDataContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MessageWindow>();
        })
        .Build();

    public static T GetService<T>() where T : class
    {
        /* Método utilizado no Template Studio do WINUI3
         para requisitar serviços do container
        ou lançar exceção quando o solicitado não estiver registrado
         */

        if (MainHost.Services.GetService(typeof(T)) is not T service)
            throw new ArgumentException(
                $"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");

        return service;
    }
}