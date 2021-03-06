﻿using CloudNimble.BlazorEssentials.TestApp.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudNimble.BlazorEssentials.TestApp
{

    /// <summary>
    /// 
    /// </summary>
    public class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IndexViewModel>();
            builder.Services.AddSingleton<SecuredPageViewModel>();
            builder.Services.AddSingleton<AdminPageViewModel>();
            builder.Services.AddSingleton(ConfigurationHelper<ConfigurationBase>.GetConfigurationFromJson());
            builder.Services.AddSingleton<BlazorAuthenticationConfig, TestAppAuthenticationConfig>();
            builder.Services.AddSingleton<AppStateBase>();

            await builder.Build().RunAsync().ConfigureAwait(false);
        }

    }

}
