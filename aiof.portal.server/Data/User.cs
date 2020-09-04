using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace aiof.portal.server.Data
{
    public class User
    {
        [JsonPropertyName("user.id")]
        public int Id { get; set; }

        [JsonPropertyName("publicKey")]
        public Guid PublicKey { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [Required]
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [Required]
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
