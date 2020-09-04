using System;
using System.Net.Http;
using System.Threading.Tasks;

using aiof.portal.Models;

namespace aiof.portal.Services
{
    public interface IAuthService
    {
        User User { get; }
        Task Initialize();
        Task LoginAsync(
            string username,
            string password);
        Task LogoutAsync();
    }
}