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
            Blur(image, 1).Save("out_blur.png", System.Drawing.Imaging.ImageFormat.Png);
            Blur(image, 2).Save("out_blurExtra.png", System.Drawing.Imaging.ImageFormat.Png);
            Darken(image).Save("out_dark.png", System.Drawing.Imaging.ImageFormat.Png);
            Sharpen(image).Save("out_sharp.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public static Bitmap Blur(Bitmap image, int strength)
        {
            if (strength == 0)
            {
                return image;
            }

            var matrixSize = strength * 2 + 1;

            if (strength < 0 || matrixSize > image.Width || matrixSize > image.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(strength), "Значение силы эффекта должно быть больше или равно 0 и меньше половины размера изображения");
            }

            var factor = 1 / Math.Pow(matrixSize, 2);
            var shaderMatrix = new double[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    shaderMatrix[j, i] = factor;
                }
            }

            return ShaderFiltration(image, shaderMatrix);
        }

        public static Bitmap Darken(Bitmap image)
        {
            return ShaderFiltration(image, new[,] { { 0.75 } });
        }

        public static Bitmap Sharpen(Bitmap image)
        {
            var shaderMatrix = new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            return ShaderFiltration(image, shaderMatrix);
        }

        public static Bitmap ShaderFiltration(Bitmap image, double[,] shaderMatrix)
        {
            var matrixSize = shaderMatrix.GetLength(0);
            if (matrixSize % 2 == 0 || matrixSize != shaderMatrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException(nameof(shaderMatrix), "Матрица эффектов должна быть квадратной матрицей нечетной размерности");
            }

            var width = image.Width;
            var height = image.Height;

            if (width < matrixSize || height < matrixSize)
            {
                throw new ArgumentOutOfRangeException(nameof(shaderMatrix), "Матрица эффектов не должна быть больше размеров исходного изображения");
            }

            var margin = (matrixSize - 1) / 2;

            var resultImage = new Bitmap(image);

            for (int y = margin; y < height - margin; ++y)
            {
                for (int x = margin; x < width - margin; ++x)
                {
                    var rLevel = 0.0;
                    var gLevel = 0.0;
                    var bLevel = 0.0;

                    for (int i = y - margin, iFx = 0; i <= y + margin; i++, iFx++)
                    {
                        for (int j = x - margin, jFx = 0; j <= x + margin; j++, jFx++)
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