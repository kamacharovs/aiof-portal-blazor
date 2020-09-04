using System;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace aiof.portal.Services
{
    public class CookieStorageService : ICookieStorageService
    {
        public readonly IJSRuntime _jsRuntime;

        public CookieStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public async Task<T> SetAsync<T>(
            string key,
            DateTime expires,
            string path = "/")
        {
            var json = await _jsRuntime.InvokeAsync<string>("document.cookie = \"username=John Doe\"");

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}