using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RNN.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public class ImageProcessingService : IImageProcessingService
    {
        private IWebHostEnvironment _environment { get; set; }

        public ImageProcessingService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string ProcessFormImage(IFormFile file)
        {
            string imageName = String.Concat(Guid.NewGuid().ToString(), ".jpg");
            var fileName = Path.Combine(_environment.WebRootPath, "images", "uploads", imageName);

            SaveFormFileAsJpg(file, fileName);
            Compress(fileName);

            return imageName;
        }

        private void SaveFormFileAsJpg(IFormFile file, string output)
        {
            using (MagickImage image = new MagickImage(file.OpenReadStream()))
            {
                image.Format = MagickFormat.Jpg;
                image.Write(output);
            }
        }

        private static void Compress(string file)
        {
            ImageOptimizer optimizer = new ImageOptimizer()
            {
                OptimalCompression = true,
                IgnoreUnsupportedFormats = true
            };

            optimizer.LosslessCompress(file);
        }
    }
}
