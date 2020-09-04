using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using aiof.portal.server.Data;

namespace aiof.portal.server.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
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
