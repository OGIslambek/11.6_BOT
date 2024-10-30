﻿using _11._6_BOT.Configuration;
using _11._6_BOT.Controllers;
using _11._6_BOT.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;

namespace _11._6_BOT
{
    internal class Program
    {
        //Входная точка
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервис запущен");

            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        //Метод для конфигурации
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "6804454204:AAGjSJvJdiI2QxeqIWDN6DdpgUJD4l-W8GY"
            };
        }
        //Конфигурация
        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();


            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            services.AddTransient<DefaultMessageController>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();
        }
    }
}
