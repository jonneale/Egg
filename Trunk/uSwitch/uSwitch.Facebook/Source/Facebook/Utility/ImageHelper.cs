using System.Drawing;
using System.IO;

namespace Facebook.Utility {
    internal sealed class ImageHelper {
        private ImageHelper() {
        }

        internal static Image ConvertBytesToImage(byte[] imageBytes) {
            Image image;
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = Image.FromStream(ms, true);
            }
            return image;
        }
    }
}