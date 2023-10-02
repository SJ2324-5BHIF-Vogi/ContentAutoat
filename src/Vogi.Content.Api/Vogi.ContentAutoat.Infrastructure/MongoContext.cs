using MongoDB.Driver;

namespace Vogi.ContentAutoat.Infrastructure
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string ConnectionString, string Database)
        {
            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase(Database);
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(nameof(T));
        }
    }
}