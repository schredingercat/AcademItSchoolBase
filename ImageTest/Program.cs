using System.Drawing;

namespace ImageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxRgb = 255;
            Bitmap image = new Bitmap("image.jpg");
            
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color newColor = Color.FromArgb(maxRgb - pixel.R, maxRgb - pixel.G, maxRgb - pixel.B);
                    
                    image.SetPixel(x, y, newColor);
                }
            }

            image.Save("out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
