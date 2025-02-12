namespace Shared.Infrastructure
{
    public static class SharedSettings
    {
        private static readonly string Secret = Environment.GetEnvironmentVariable("SECRET") ?? "";


        /* variáveis para configurar o keycloak */
        public static readonly string kcAuthUrl = Environment.GetEnvironmentVariable("KC_AUTH_URL") ?? "https://82.29.59.187:8081";
        public static readonly string kcRealm = Environment.GetEnvironmentVariable("KC_REALM") ?? "BandaApp";
        public static readonly string kcSslRequired = Environment.GetEnvironmentVariable("KC_SSL_REQUIRED") ?? "none";
        public static readonly string kcClientId = Environment.GetEnvironmentVariable("KC_CLIENT_ID") ?? "pdaf-api";
        public static readonly string kcClientSecret = Environment.GetEnvironmentVariable("KC_CLIENT_SECRET") ?? "peeQDa3V8T5gA01wkEonYt6ULGgxJQgi";
        public static string SecretKey => Secret;
    }
}
