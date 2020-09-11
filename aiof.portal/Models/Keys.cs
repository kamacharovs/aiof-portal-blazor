using System;

namespace aiof.portal.Models
{
    public static class Keys
    {
        public static string User = nameof(User);

        public static string Auth = nameof(Auth);
        public static string BaseUrl = nameof(BaseUrl);
        public static string AuthBaseUrl = Auth + ":" + BaseUrl;

        public static string AccessToken = "access_token";
    }
}