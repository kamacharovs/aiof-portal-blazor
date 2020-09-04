using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Components;

using Blazored.LocalStorage;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public class AuthService : IAuthService
    {
        public readonly IAuthClient _client;
        public readonly ILocalStorageService _localStorageService;
        public readonly NavigationManager _navigationManager;

        public AuthService(
            IAuthClient client,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }

        public async Task LoginAsync(
            string username,
            string password)
        {
            var resp = await _client.LoginAsync(username, password);

            if(resp.IsSuccessStatusCode)
            {
                var user = JsonSerializer.Deserialize<User>(await resp.Content.ReadAsByteArrayAsync());
                await _localStorageService.SetItemAsync(Keys.User, user);
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(Keys.User);
            _navigationManager.NavigateTo("login");
        }
    }
}