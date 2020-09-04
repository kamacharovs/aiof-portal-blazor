using System;
using System.Net.Http;
using System.Threading.Tasks;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public interface IAuthService
    {
        Task<User> LoginAsync(
            string username,
            string password);
    }
}