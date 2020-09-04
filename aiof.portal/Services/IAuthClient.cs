using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace aiof.portal.Services
{
    public interface IAuthClient
    {
        Task<HttpResponseMessage> LoginAsync(
            string username,
            string password);
    }
}