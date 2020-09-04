using System;
using System.Threading.Tasks;

namespace aiof.portal.Services
{
    public interface ICookieStorageService
    {
        Task<T> SetAsync<T>(
            string key,
            DateTime expires,
            string path = "/");
    }
}