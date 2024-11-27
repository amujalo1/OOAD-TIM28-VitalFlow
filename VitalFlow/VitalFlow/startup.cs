﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using VitalFlow.Data;
using VitalFlow.Models;

namespace VitalFlow
{
    public class startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Ostale konfiguracije servisa

            // Dodavanje logiranja
            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Dodajte ostale providere po potrebi (npr. AddDebug, AddFile, itd.)
            });

            // Ostale konfiguracije
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ostale konfiguracije aplikacije

            // Dodavanje middleware-a za logiranje zahtjeva
            app.UseMiddleware<RequestLoggingMiddleware>();

            // Ostale konfiguracije
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders(); // Uklonite postojeće providere logova ako želite
            logging.AddConsole(); // Dodajte ConsoleLoggerProvider
            // Možete dodati i druge providere kao što su Debug, EventLog itd.
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<startup>();
        });

    }
}
