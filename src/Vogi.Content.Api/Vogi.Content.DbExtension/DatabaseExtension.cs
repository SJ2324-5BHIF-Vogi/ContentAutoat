using Microsoft.Extensions.DependencyInjection;
using Vogi.ContentAutoat.Domain.Configuration;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Infrastructure;

namespace Vogi.ContentAutoat.DbExtension
{
    public static class DatabaseExtensions
    {
        public static void ConfigureMongo(this IServiceCollection services, DataBaseCo databaseCo)
        {
            services.AddScoped<IMongoContext>(serviceProvider =>
            {
                return new MongoContext(databaseCo);
            });
        }
    }
}