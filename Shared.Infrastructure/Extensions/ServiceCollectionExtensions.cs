using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Controllers;

namespace Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;

        }

        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddSQL<T>(connectionString);

            return services;
        }

        private static IServiceCollection AddSQL<T>(this IServiceCollection services, string connectionString) where T: DbContext
        {
            services.AddDbContext<T>(m =>
            m.UseSqlServer(connectionString, e =>
            e.MigrationsAssembly(typeof(T).Assembly.FullName)));

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();

            return services;
        }
    }
}
