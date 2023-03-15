using System.Drawing;

namespace AdminPanel.Web.Services
{
    public interface IImageService
    {
        Bitmap Resize(Image image);
        byte[] ImageToByte(Image img);
        string GeneratePath(string userId, string fileName);
        Bitmap GetImageBitmap(string path);
    }
}
