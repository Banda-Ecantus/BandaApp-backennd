namespace Shared.Infrastructure
{
    public static class SharedSettings
    {
        //private static readonly string postgreServer = Environment.GetEnvironmentVariable("POSTGRES_SERVER_URL") ?? "82.29.59.187";
        //private static readonly string postgreServerPort = Environment.GetEnvironmentVariable("POSTGRES_SERVER_PORT") ?? "26257";
        //private static readonly string postgreDataBase = Environment.GetEnvironmentVariable("POSTGRES_SERVER_DATABASE") ?? "inventory";

        //private static readonly string postgreUsername = Environment.GetEnvironmentVariable("DB_POSTGRES_USERNAME") ?? "roach";
        //private static readonly string postgresPassword = Environment.GetEnvironmentVariable("DB_POSTGRES_PASSWORD") ?? "XCfpjU@JVHbuGy9zE#gQ6Bsh";

        //private static readonly string postgresConnectionString = @$"Host={postgreServer};Port={postgreServerPort};Database={postgreDataBase};Username={postgreUsername};Password={postgresPassword};";


        private static string Secret = Environment.GetEnvironmentVariable("SECRET") ?? "";


        /* variáveis para configurar o keycloak */
        public static readonly string kcAuthUrl = Environment.GetEnvironmentVariable("KC_AUTH_URL") ?? "http://keycloak-homolog.se.df.gov.br/auth";
        public static readonly string kcRealm = Environment.GetEnvironmentVariable("KC_REALM") ?? "BandaApp";
        public static readonly string kcSslRequired = Environment.GetEnvironmentVariable("KC_SSL_REQUIRED") ?? "none";
        public static readonly string kcClientId = Environment.GetEnvironmentVariable("KC_CLIENT_ID") ?? "pdaf-api";
        public static readonly string kcClientSecret = Environment.GetEnvironmentVariable("KC_CLIENT_SECRET") ?? "peeQDa3V8T5gA01wkEonYt6ULGgxJQgi";
        //public static string PostgresConnectionString => postgresConnectionString;
        public static string SecretKey => Secret;
    }
}
