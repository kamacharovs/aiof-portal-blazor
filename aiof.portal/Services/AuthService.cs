using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components.Authorization;

using Blazored.LocalStorage;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public class AuthService : IAuthService
    {
        public readonly IAuthClient _client;
        public readonly ILocalStorageService _localStorageService;
        public readonly AuthenticationStateProvider _authenticationStateProvider;
        public readonly NavigationManager _navigationManager;

        public AuthService(
            IAuthClient client,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigationManager)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
            _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }

        public async Task LoginAsync(
            string username,
            string password)
        {
            var resp = (await _client.LoginAsync(username, password)).EnsureSuccessStatusCode();

            var user = JsonSerializer.Deserialize<User>(await resp.Content.ReadAsByteArrayAsync());
            await _localStorageService.SetItemAsync(Keys.User, user);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
            _navigationManager.NavigateTo("/");
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(Keys.User);
            _navigationManager.NavigateTo("login");
        }
    }
}