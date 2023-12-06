using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Interfaces.Repository
{
    public interface IContentReadRepository
    {
        ContentData? FindByGuid(Guid guid);
        IEnumerable<ContentData> GetAll(int Page, int PageSize, Guid? User = null, DateTime? VorGrenze = null, DateTime? NachGrenze = null);
    }
}