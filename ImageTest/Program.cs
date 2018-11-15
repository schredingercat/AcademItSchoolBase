using System;
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
            Sharpen(image).Save("out_sharp.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public static Bitmap Blur(Bitmap image)
        {
            var factor = (double)1 / 9;
            var shaderMatrix = new[,] { { factor, factor, factor }, { factor, factor, factor }, { factor, factor, factor } };
            return ShaderFiltration(image, shaderMatrix);
        }

        public static Bitmap Sharpen(Bitmap image)
        {
            var shaderMatrix = new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            return ShaderFiltration(image, shaderMatrix);
        }

        public static Bitmap ShaderFiltration(Bitmap image, double[,] shaderMatrix)
        {
            if (shaderMatrix.GetLength(0) != 3 || shaderMatrix.GetLength(1) != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(shaderMatrix), "Матрица эффектов должна иметь размерность 3x3");
            }

            var width = image.Width;
            var height = image.Height;
            var resultImage = new Bitmap(image);

            for (int y = 1; y < height - 1; ++y)
            {
                for (int x = 1; x < width - 1; ++x)
                {
                    var rLevel = 0.0;
                    var gLevel = 0.0;
                    var bLevel = 0.0;

                    for (int i = y - 1, iFx = 0; i <= y + 1; i++, iFx++)
                    {
                        for (int j = x - 1, jFx = 0; j <= x + 1; j++, jFx++)
                        {
                            var pixel = image.GetPixel(j, i);
                            rLevel += pixel.R * shaderMatrix[jFx, iFx];
                            gLevel += pixel.G * shaderMatrix[jFx, iFx];
                            bLevel += pixel.B * shaderMatrix[jFx, iFx];
                        }
                    }

                    Color newColor = Color.FromArgb(Saturate(rLevel), Saturate(gLevel), Saturate(bLevel));
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