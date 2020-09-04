using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace aiof.portal.Services
{
    public interface IAuthService
    {
        Task<HttpResponseMessage> LoginAsync(
            string username,
            string password);
    }
}