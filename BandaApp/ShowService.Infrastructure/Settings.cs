using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowService.Infrastructure
{
    public static class Settings
    {
        private static readonly string postgreServer = Environment.GetEnvironmentVariable("POSTGRES_SERVER_URL") ?? "82.29.59.187";
        private static readonly string postgreServerPort = Environment.GetEnvironmentVariable("POSTGRES_SERVER_PORT") ?? "26257";
        private static readonly string postgreDataBase = Environment.GetEnvironmentVariable("POSTGRES_SERVER_DATABASE") ?? "show";

        private static readonly string postgreUsername = Environment.GetEnvironmentVariable("DB_POSTGRES_USERNAME") ?? "roach";
        private static readonly string postgresPassword = Environment.GetEnvironmentVariable("DB_POSTGRES_PASSWORD") ?? "XCfpjU@JVHbuGy9zE#gQ6Bsh";

        private static readonly string postgresConnectionString = @$"Host={postgreServer};Port={postgreServerPort};Database={postgreDataBase};Username={postgreUsername};Password={postgresPassword};";


        private static string Secret = Environment.GetEnvironmentVariable("SECRET") ?? "";

        public static string PostgresConnectionString => postgresConnectionString;

        /* variáveis para configurar o keycloak */

        public static readonly string kcClientInventoryId = Environment.GetEnvironmentVariable("KC_CLIENT_ID_INVENTORY") ?? "bandaapp_backend_inventory";
        public static readonly string kcClientInventorySecret = Environment.GetEnvironmentVariable("KC_CLIENT_SECRET_INVENTORY") ?? "FRMpuNwvoix6NYfbfsRIkUpxGwzEl1zy";
        public static string SecretKey => Secret;
    }
}
