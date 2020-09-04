using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.Extensions.Logging;

namespace aiof.portal.Services
{
    public class AuthClient : IAuthClient
    {
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        public AuthClient(
            ILogger<AuthClient> logger,
            HttpClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _client.BaseAddress = new Uri("http://localhost:5000");
        }

        public async Task<HttpResponseMessage> LoginAsync(
            string username,
            string password)
        {
            try
            {
                var req = JsonSerializer.Serialize(new { username, password });
                var resp = await _client.PostAsync("/auth/token", new StringContent(req, Encoding.UTF8, "application/json"));

                return resp;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
