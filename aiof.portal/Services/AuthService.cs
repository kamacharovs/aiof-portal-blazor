using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace aiof.portal.Services
{
    public class AuthService : IAuthService
    {
        public readonly IAuthClient _client;
        public readonly ILocalStorageService _localStorageService;

        public AuthService(
            IAuthClient client,
            ILocalStorageService localStorageService)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
        }

        public async Task<HttpResponseMessage> LoginAsync(
            string username,
            string password)
        {
            return await _client.LoginAsync(username, password);
        }
    }
}