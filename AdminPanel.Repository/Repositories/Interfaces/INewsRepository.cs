using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface INewsRepository : IBaseRepository<News, NewsFilter>
    {
        News FindOrCreate(int? id);
        News[] GetAllNews();
    }
}