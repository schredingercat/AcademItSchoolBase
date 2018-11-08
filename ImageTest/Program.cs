using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageTest
{
    class Program
    {
        static void Main()
        {
            Bitmap image = new Bitmap("image.jpg");

            ToBlackAndWhite(image).Save("out_bw.png", System.Drawing.Imaging.ImageFormat.Png);
            Blur(image).Save("out_blur.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public static Bitmap Blur(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;
            var resultImage = new Bitmap(image);

            for (int y = 1; y < height - 1; ++y)
            {
                for (int x = 1; x < width - 1; ++x)
                {
                    var pixels = new List<Color>();

                    for (int i = y - 1; i <= y + 1; i++)
                    {
                        for (int j = x - 1; j <= x + 1; j++)
                        {
                            pixels.Add(image.GetPixel(j, i));
                        }
                    }

                    var rLevel = 0;
                    var gLevel = 0;
                    var bLevel = 0;

                    foreach (var pixel in pixels)
                    {
                        rLevel += pixel.R;
                        gLevel += pixel.G;
                        bLevel += pixel.B;
                    }

                    rLevel = Saturate((double)rLevel / 9);
                    gLevel = Saturate((double)gLevel / 9);
                    bLevel = Saturate((double)bLevel / 9);

                    Color newColor = Color.FromArgb(rLevel, gLevel, bLevel);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        public static Bitmap ToBlackAndWhite(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;
            var resultImage = new Bitmap(width, height);

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Color pixel = image.GetPixel(x, y);
                    var rgbLevel = (int)Math.Round(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
                    Color newColor = Color.FromArgb(rgbLevel, rgbLevel, rgbLevel);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        public static int Saturate(double input)
        {
            if (input < 0)
            {
                return 0;
            }

            if (input > 255)
            {
                return 255;
            }

            return (int)Math.Round(input);
        }
    }
}
