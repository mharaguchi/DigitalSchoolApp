using DbUp;
using System.Reflection;

namespace DigitalSchoolApi.Api
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder RunDatabaseMigrations<TContext>(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                logger.LogInformation("Running DB migrations");

                string connection = configuration.GetValue<string>("DigitalSchoolApiOptions:ConnectionString") ?? throw new Exception("Connection string not found");

                EnsureDatabase.For.PostgresqlDatabase(connection);

                var upgrader = DeployChanges.To
                    .PostgresqlDatabase(connection)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    logger.LogError(result.Error, "Error running DB migrations");
                    return app;
                }

                logger.LogInformation("DB migrations complete");
            }

            return app;
        }
    }
}
