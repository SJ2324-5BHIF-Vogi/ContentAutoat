using MongoDB.Driver;
using Vogi.ContentAutoat.Domain.Configuration;

namespace Vogi.ContentAutoat.Infrastructure
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(DataBaseCo databaseCo)
        {
            var client = new MongoClient(databaseCo.ConnectionString);
            _database = client.GetDatabase(databaseCo.DataBaseName);
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(nameof(T));
        }
    }
}