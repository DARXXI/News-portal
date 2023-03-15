using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Image = AdminPanel.Domain.Entities.Image;

namespace AdminPanel.Repository.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task Add(Image image)
        {
            await Context.Images.AddAsync(image);
            await Context.SaveChangesAsync();
        }

        public Image Find(string hash)
        {
            var image =  Context.Images.OrderBy(t => t.Id).Last(t => t.Hash == hash);
            return image;
        }

        public Image Find(int id)
        {
            var image = Context.Images.Find(id);
            return image;
        }

        public async Task UpdateAvatar(Image image, int userId, CancellationToken cancellationToken)
        {
            await Add(image);
            var user = await Context.Users.FindAsync(userId);
            if (user != null)
            {
                Context.Users.Update(user);
                user.ImageId = image.Id;
            }
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
