namespace Shared.Infrastructure
{
    public static class SharedSettings
    {
        private static readonly string Secret = Environment.GetEnvironmentVariable("SECRET") ?? "";


        /* variáveis para configurar o keycloak */
        public static readonly string kcAuthUrl = Environment.GetEnvironmentVariable("KC_AUTH_URL") ?? "https://vinicius.karinzitta.dev:8082/";
        public static readonly string kcRealm = Environment.GetEnvironmentVariable("KC_REALM") ?? "dev";
        public static readonly string kcSslRequired = Environment.GetEnvironmentVariable("KC_SSL_REQUIRED") ?? "none";
        public static readonly string kcClientId = Environment.GetEnvironmentVariable("KC_CLIENT_ID") ?? "bandaapp_backend";
        public static readonly string kcClientSecret = Environment.GetEnvironmentVariable("KC_CLIENT_SECRET") ?? "d4VnETr5fLSmHflXkp01DFL5xPOhorhw";
        public static string SecretKey => Secret;
    }
}
