using System;
using System.Threading.Tasks;
using System.Security.Claims;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public class AiofAuthenticationStateProvider : AuthenticationStateProvider
    {
        public readonly ILocalStorageService _storageService;

        public AiofAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(await _storageService.ContainKeyAsync(Keys.User))
            {
                var userInfo = await _storageService.GetItemAsync<User>(Keys.User);
                var claims = new[]
                {
                    new Claim(Keys.AccessToken, userInfo.AccessToken),
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state)); 
                return state; 
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}