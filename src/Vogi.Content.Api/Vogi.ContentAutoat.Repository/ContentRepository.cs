using Vogi.ContentAutoat.Infrastructure;
using System.Linq;
using MongoDB.Driver;
using Vogi.ContentAutoat.Domain.Model;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;

namespace Vogi.ContentAutoat.Repository
{
    public class ContentRepository : IContentWriteRepository, IContentReadRepository
    {
        private readonly MongoContext _context;
        public ContentRepository(MongoContext context)
        {
            _context = context;
        }

        public IEnumerable<Content> GetAll(int Page, int PageSize, Guid? User = null, DateTime? VorGrenze = null, DateTime? NachGrenze = null)
        {
            var filter = Builders<Content>.Filter.Empty;

            if (User.HasValue)
            {
                filter &= Builders<Content>.Filter.Eq(c => c.User, User.Value);
            }

            if (VorGrenze.HasValue)
            {
                filter &= Builders<Content>.Filter.Gte(c => c.Posted, VorGrenze.Value);
            }

            if (NachGrenze.HasValue)
            {
                filter &= Builders<Content>.Filter.Lte(c => c.Posted, NachGrenze.Value);
            }

            var Result = _context.GetCollection<Content>()
                                 .Find(filter)
                                 .Skip((Page - 1) * PageSize)
                                 .Limit(PageSize)
                                 .ToEnumerable();

            return Result;
        }

        public Content? FindByGuid(Guid guid)
        {
            var filter = Builders<Content>.Filter.Eq(c => c.Guid, guid);
            return _context.GetCollection<Content>().Find(filter).SingleOrDefault();
        }

        public void Add(Content content)
        {
            _context.GetCollection<Content>().InsertOne(content);
        }

        public bool Update(Guid guid, Content updatedContent)
        {
            var filter = Builders<Content>.Filter.Eq(c => c.Guid, guid);
            var result = _context.GetCollection<Content>().ReplaceOne(filter, updatedContent);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public bool Delete(Guid guid)
        {
            var filter = Builders<Content>.Filter.Eq(c => c.Guid, guid);
            var result = _context.GetCollection<Content>().DeleteOne(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}