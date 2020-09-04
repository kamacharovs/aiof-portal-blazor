using System;

namespace aiof.portal.Services
{
    public class AuthService : IAuthService
    {
        public ILocalStorageService _localStorageService;

        public AuthService(
            ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
        }
    }
}