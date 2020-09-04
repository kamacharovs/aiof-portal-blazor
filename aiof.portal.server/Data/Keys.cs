using System;

namespace aiof.portal.server.Data
{
    public static class Keys
    {
        public static string User = nameof(User);

        public static string Auth = nameof(Auth);
        public static string BaseUrl = nameof(BaseUrl);
        public static string AuthBaseUrl = nameof(Auth) + ":" + nameof(BaseUrl);
        public static string AccessToken = "access_token";
    }
}