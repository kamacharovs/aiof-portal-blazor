using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Blazored.LocalStorage;

using aiof.portal.Services;

namespace aiof.portal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddAuthorizationCore();
            builder.Services
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000") })
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<AuthenticationStateProvider, AiofAuthenticationStateProvider>()
                .AddScoped<ICookieStorageService, CookieStorageService>()
                .AddBlazoredLocalStorage()
                .AddLogging();

            builder.RootComponents.Add<App>("app");

            await builder
                .Build()
                .RunAsync();
        }
    }
}
