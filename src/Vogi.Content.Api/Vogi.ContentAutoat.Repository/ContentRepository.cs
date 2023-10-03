using Vogi.ContentAutoat.Infrastructure;
using System.Linq;
using MongoDB.Driver;
using Vogi.ContentAutoat.Domain.Model;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;

namespace Vogi.ContentAutoat.Repository
{
    public class ContentRepository : IContentWriteRepository, IContentReadRepository
    {
        private readonly IMongoContext _context;
        private readonly IToEnumerable _toEnumerable;
        private readonly IFindFluentFind _findFluentFind;
        private readonly ISingleOrDefault _singleOrDefault;

        public ContentRepository(IMongoContext context, IToEnumerable toEnumerable, IFindFluentFind findFluentFind, ISingleOrDefault singleOrDefault)
        {
            _context = context;
            _toEnumerable = toEnumerable;
            _findFluentFind = findFluentFind;
            _singleOrDefault = singleOrDefault;
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

            var Result = _toEnumerable.ToEnumerable(
                _findFluentFind.Find(_context.GetCollection<Content>(), filter)
                                 .Skip((Page - 1) * PageSize)
                                 .Limit(PageSize)
                                 );

            return Result;
        }

        public Content? FindByGuid(Guid guid)
        {
            var filter = Builders<Content>.Filter.Eq(c => c.Guid, guid);
            return _singleOrDefault.SingleOrDefault(_findFluentFind.Find(_context.GetCollection<Content>(),filter));
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