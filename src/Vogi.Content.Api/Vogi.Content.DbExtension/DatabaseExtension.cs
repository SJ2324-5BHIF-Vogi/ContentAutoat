using Microsoft.Extensions.DependencyInjection;
using Vogi.ContentAutoat.Domain.Configuration;
using Vogi.ContentAutoat.Infrastructure;

namespace Vogi.Content.DbExtension
{
    public static class DatabaseExtensions
    {
        public static void ConfigureMongo(this IServiceCollection services, DataBaseCo databaseCo)
        {
            services.AddScoped(serviceProvider =>
            {
                return new MongoContext(databaseCo);
            });
        }
    }
}