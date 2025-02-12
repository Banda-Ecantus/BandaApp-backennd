namespace Shared.Infrastructure
{
    public static class Settings
    {
        private static readonly string postgreServer = Environment.GetEnvironmentVariable("POSTGRES_SERVER_URL") ?? "82.29.59.187";
        private static readonly string postgreServerPort = Environment.GetEnvironmentVariable("POSTGRES_SERVER_PORT") ?? "26257";
        private static readonly string postgreDataBase = Environment.GetEnvironmentVariable("POSTGRES_SERVER_DATABASE") ?? "inventory";

        private static readonly string postgreUsername = Environment.GetEnvironmentVariable("DB_POSTGRES_USERNAME") ?? "roach";
        private static readonly string postgresPassword = Environment.GetEnvironmentVariable("DB_POSTGRES_PASSWORD") ?? "XCfpjU@JVHbuGy9zE#gQ6Bsh";

        private static readonly string postgresConnectionString = @$"Host={postgreServer};Port={postgreServerPort};Database={postgreDataBase};Username={postgreUsername};Password={postgresPassword};";


        private static string Secret = Environment.GetEnvironmentVariable("SECRET") ?? "";

        public static string PostgresConnectionString => postgresConnectionString;
        public static string SecretKey => Secret;
    }
}
