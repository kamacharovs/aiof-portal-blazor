using System.Threading.Tasks;

using aiof.portal.server.Data;

namespace aiof.portal.server.Services
{
    public interface IAuthService
    {
        Task<User> LoginAsync(
            string username, 
            string password);
    }
}