using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Interfaces.Repository
{
    public interface IContentWriteRepository
    {
        void Add(ContentData content);
        bool Delete(Guid guid);
        int Update(Guid guid, ContentData updatedContent);
    }
}