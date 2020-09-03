using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Authorization;

using Blazored.LocalStorage;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly ILocalStorageService _storageService;
        private readonly string _userKey = nameof(User).ToLowerInvariant();

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync(_userKey))
            {
                var user = await _storageService.GetItemAsync<User>(_userKey);
                var claims = new[]
                {
                    new Claim("access_token", user.AccessToken),
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var state = new AuthenticationState(new ClaimsPrincipal(identity));
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync(_userKey);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
