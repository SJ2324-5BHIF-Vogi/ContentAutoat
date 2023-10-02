using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Interfaces.Repository
{
    public interface IContentReadRepository
    {
        Content? FindByGuid(Guid guid);
        IEnumerable<Content> GetAll(int Page, int PageSize, Guid? User = null, DateTime? VorGrenze = null, DateTime? NachGrenze = null);
    }
}