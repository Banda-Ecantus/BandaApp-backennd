namespace Shared.Infrastructure
{
    public static class Settings
    {
        private static readonly string postgreServer = Environment.GetEnvironmentVariable("POSTGRES_SERVER_URL") ?? "10.230.84.94";
        private static readonly string postgreDataBase = Environment.GetEnvironmentVariable("POSTGRES_SERVER_DATABASE") ?? "master";
        private static readonly string postgreUsername = Environment.GetEnvironmentVariable("DB_POSTGRES_USERNAME") ?? "usr_sed";
        private static readonly string postgresPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "kNQ4hK57Yk";
        private static readonly string connectionString = @$"Host={postgreServer};Database={postgreDataBase};Username={postgreUsername};Password={postgresPassword};";

        public const string Secret = "";


        /* variáveis para configurar o keycloak */
        public static readonly string kcAuthUrl = Environment.GetEnvironmentVariable("KC_AUTH_URL") ?? "http://keycloak-homolog.se.df.gov.br/auth";
        public static readonly string kcRealm = Environment.GetEnvironmentVariable("KC_REALM") ?? "BandaApp";
        public static readonly string kcSslRequired = Environment.GetEnvironmentVariable("KC_SSL_REQUIRED") ?? "none";
        public static readonly string kcClientId = Environment.GetEnvironmentVariable("KC_CLIENT_ID") ?? "pdaf-api";
        public static readonly string kcClientSecret = Environment.GetEnvironmentVariable("KC_CLIENT_SECRET") ?? "peeQDa3V8T5gA01wkEonYt6ULGgxJQgi";
        public static string ConnectionString => connectionString;
    }
}
