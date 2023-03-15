using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Configurations;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IImageRepository
    {
        Task Add(Image image);
        Image Find(int id);
        Image Find(string hash);
        Task UpdateAvatar(Image image, int userId, CancellationToken cancellationToken);
    }
}