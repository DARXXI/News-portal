using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IBaseRepository<T, TFilter> where T : BaseEntity
                                                 where TFilter : BaseFilter
    {
        T Create();
        BaseModel<T> All(TFilter filter);
        Task<T> FindAsync(int id,CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
