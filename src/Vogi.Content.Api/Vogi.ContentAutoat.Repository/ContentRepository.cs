using Vogi.ContentAutoat.Infrastructure;
using System.Linq;
using MongoDB.Driver;
using Vogi.ContentAutoat.Domain.Model;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using MongoDB.Bson;

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

        public IEnumerable<ContentData> GetAll(int Page, int PageSize, Guid? User = null, DateTime? VorGrenze = null, DateTime? NachGrenze = null)
        {
            var filter = Builders<ContentData>.Filter.Empty;

            if (User.HasValue)
            {
                filter &= Builders<ContentData>.Filter.Eq(c => c.User, User.Value);
            }

            if (VorGrenze.HasValue)
            {
                filter &= Builders<ContentData>.Filter.Gte(c => c.Posted, VorGrenze.Value);
            }

            if (NachGrenze.HasValue)
            {
                filter &= Builders<ContentData>.Filter.Lte(c => c.Posted, NachGrenze.Value);
            }

            var Result = _toEnumerable.ToEnumerable(
                _findFluentFind.Find(_context.GetCollection<ContentData>(), filter)
                                 .Skip((Page - 1) * PageSize)
                                 .Limit(PageSize)
                                 );

            return Result;
        }

        public ContentData? FindByGuid(Guid guid)
        {
            var filter = Builders<ContentData>.Filter.Eq(c => c.Guid, guid);
            return _singleOrDefault.SingleOrDefault(_findFluentFind.Find(_context.GetCollection<ContentData>(),filter));
        }

        public void Add(ContentData content)
        {
            _context.GetCollection<ContentData>().InsertOne(content);
        }

        public int Update(Guid guid, ContentData updatedContent)
        {
            if (updatedContent.Titel == null && updatedContent.Data == null)
            {
                return 0;
            }

            var filter = Builders<ContentData>.Filter.Eq(c => c.Guid, guid);
            var update = Builders<ContentData>.Update.Combine();

            if(updatedContent.Data != null)
            {
                update.Set(c=>c.Data,updatedContent.Data);
            }
            if (updatedContent.Titel != null)
            {
                update.Set(c => c.Titel, updatedContent.Titel);
            }

            var result = _context.GetCollection<ContentData>().UpdateOne(filter, update);
            return (int)result.ModifiedCount;
        }

        public bool Delete(Guid guid)
        {
            var filter = Builders<ContentData>.Filter.Eq(c => c.Guid, guid);
            var a = filter.ToBson();
            var result = _context.GetCollection<ContentData>().DeleteOne(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}