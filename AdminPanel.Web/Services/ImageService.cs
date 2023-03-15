using System.Drawing;

namespace AdminPanel.Web.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;

        public ImageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Bitmap Resize(Image image)
        {
            var scale = (float)_configuration.GetValue<int>("AvatarHeight") / (float)image.Size.Height;
            return new Bitmap(image, new Size((int)(image.Width * scale), (int)(image.Height * scale)));
        }

        public byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public string GeneratePath(string userId, string fileName)
        {
            const string folder = @"images\";
            var uniqueFolder = Path.Combine(folder, userId);
            var path = Path.Combine(uniqueFolder, fileName);
            if (!Directory.Exists(uniqueFolder))
            {
                Directory.CreateDirectory(uniqueFolder);
            }
            return path;
        }

        public Bitmap GetImageBitmap(string path)
        {
            var bytes = System.IO.File.ReadAllBytes(path);

            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            ms.Dispose();

            return Resize(img);
            
        }
    }
}
