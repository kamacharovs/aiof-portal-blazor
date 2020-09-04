using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace aiof.portal.Services
{
    public class AuthClient : IAuthClient
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public AuthClient(
            ILogger<AuthClient> logger,
            IConfiguration config,
            HttpClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            //_client.BaseAddress = new Uri("http://localhost:5000");
        }

        public async Task<HttpResponseMessage> LoginAsync(
            string username,
            string password)
        {
            try
            {
                return await _client.PostAsJsonAsync("/auth/token", new { username, password });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
