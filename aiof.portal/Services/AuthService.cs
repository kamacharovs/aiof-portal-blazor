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
        public readonly HttpClient _client;
        public readonly ILocalStorageService _storageService;

        public AuthService(
            HttpClient client,
            ILocalStorageService storageService)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        public async Task<User> LoginAsync(
            string username,
            string password)
        {
            var payload = JsonSerializer.Serialize(new { username, password });
            var resp = await _client.PostAsync("/auth/token", new StringContent(payload, Encoding.UTF8, "application/json"));
            return JsonSerializer.Deserialize<User>(await resp.Content.ReadAsByteArrayAsync());
        }
    }
}