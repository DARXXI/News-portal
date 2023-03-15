using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repository.Repositories
{
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public NewsRepository(DataBaseContext context) : base(context)
        {
        }

        public News FindOrCreate(int? id)
        {
            var pieceOfNews = id != null ? Context.News.Find(new object?[] { id }) : new News();
            return pieceOfNews;
        }

        public News[] GetAllNews()
        {
            return Context.News.ToArray();
        }

        public BaseModel<News> All(NewsFilter newsFilter)
        {
            var propertyGetter = DynamicExpressions.DynamicExpressions.GetPropertyGetter<News>(newsFilter.SortColumn);
            var query = Context.News.Skip(newsFilter.StartRow).Take(newsFilter.Take);

            query = newsFilter.SortOrder == SortOrder.Asc
                ? query.OrderBy(propertyGetter)
                : query.OrderByDescending(propertyGetter);
            var queryNews = query.ToArray();

            var newsModel = new BaseModel<News>() { Data = queryNews, LastRowIndex = Context.News.Count() };
            return newsModel;
        }

        public BaseModel<News> All(BaseFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<News> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await Context.News.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public News Create()    
        {
            var pieceOfNews = new News();
            return pieceOfNews;
        }

        public async Task<News> UpdateAsync(News pieceOfNews, CancellationToken cancellationToken)
        {
            if (pieceOfNews.IsNew())
            {
                pieceOfNews.DateCreated = CurrentDate;
            }
            pieceOfNews.DateUpdated = CurrentDate;

            Context.News.Update(pieceOfNews);
            await Context.SaveChangesAsync(cancellationToken);
            return pieceOfNews;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var exactPieceOfNews = await FindAsync(id, cancellationToken);
            Context.News.Remove(exactPieceOfNews);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}