using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Interfaces.Repository
{
    public interface IContentWriteRepository
    {
        void Add(Content content);
        bool Delete(Guid guid);
        bool Update(Guid guid, Content updatedContent);
    }
}