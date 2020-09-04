using System.Threading.Tasks;

namespace aiof.portal.server.Services
{
    public interface IAuthService
    {
        Task LoginAsync(
            string username, 
            string password);
    }
}