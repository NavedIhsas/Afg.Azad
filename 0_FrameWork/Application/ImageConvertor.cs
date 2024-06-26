using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static SixLabors.ImageSharp.Image;

namespace _0_FrameWork.Application
{
    public static class ImageConvertor
    {
        public static void ImageResize(string inputImagePath, string outputImagePath, int newWidth)
        {

            using var sourceBitmap = SixLabors.ImageSharp.Image.Load(inputImagePath);

            var dblWidthOriginal = sourceBitmap.Width;
            var dblHeigthOriginal = sourceBitmap.Height;

            var relationHeigthWidth = dblHeigthOriginal / dblWidthOriginal;

            var newHeight = (int)(newWidth * relationHeigthWidth);

            sourceBitmap.Mutate(x => x
                .Resize(newWidth, newHeight));

            using var imageStream = new MemoryStream();
            sourceBitmap.Save(imageStream, new WebpEncoder());
           
            using var streamImg = new FileStream(
                outputImagePath, FileMode.Create, FileAccess.Write, FileShare.Write, 4096);

            var imageBytes = imageStream.ToArray();
            streamImg.Write(imageBytes, 0, imageBytes.Length);
          
            streamImg.Dispose();
            sourceBitmap.Dispose();

        }
    }
}
