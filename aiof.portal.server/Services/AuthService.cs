using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using aiof.portal.server.Data;
using Microsoft.AspNetCore.Components;

namespace aiof.portal.server.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly NavigationManager _navigationManager;

        public AuthService(
            HttpClient client,
            NavigationManager navigationManager)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }

        public async Task LoginAsync(
            string username,
            string password)
        {
            var payload = JsonSerializer.Serialize(new { username, password });
            var resp = await _client.PostAsync("/auth/token", new StringContent(payload, Encoding.UTF8, "application/json"));

            var user = JsonSerializer.Deserialize<User>(await resp.Content.ReadAsByteArrayAsync());
            //await _localStorageService.SetItemAsync(Keys.User, user);
            //await _authenticationStateProvider.GetAuthenticationStateAsync();
            _navigationManager.NavigateTo("/");
        }
    }
}
