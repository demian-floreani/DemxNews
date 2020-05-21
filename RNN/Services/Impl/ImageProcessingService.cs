using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations;
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
            string identifier = String.Concat(Guid.NewGuid().ToString());
            string uploadPath = Path.Combine(_environment.WebRootPath, "images", "uploads");

            ResizeImageToMultipleViewSizes(file, uploadPath, identifier);

            return identifier;
        }

        private void ResizeImageToMultipleViewSizes(IFormFile file, string uploadPath, string identifier)
        {
            using (MagickImage image = new MagickImage(file.OpenReadStream()))
            {
                // create image for small devices
                ResizeTo(image, 375, "tiny", uploadPath, identifier);
            }

            using (MagickImage image = new MagickImage(file.OpenReadStream()))
            {
                if (image.Width > 540)
                {
                    // create image for medium devices
                    ResizeTo(image, 540, "medium", uploadPath, identifier);
                }
                else
                {
                    Save(image, "medium", uploadPath, identifier);
                }
            }

            using (MagickImage image = new MagickImage(file.OpenReadStream()))
            {
                if (image.Width > 720)
                {
                    // create image for large devices
                    ResizeTo(image, 720, "large", uploadPath, identifier);
                }
                else
                {
                    Save(image, "large", uploadPath, identifier);
                }
            }

        }

        private void ResizeTo(MagickImage image, int width, string device, string uploadPath, string identifier)
        {
            image.Resize(new MagickGeometry()
            {
                Width = width,
                IgnoreAspectRatio = false
            });

            Save(image, device, uploadPath, identifier);
        }

        private void Save(MagickImage image, string device, string uploadPath, string identifier)
        {
            image.Format = MagickFormat.WebP;
            image.Write(Path.Combine(uploadPath, String.Format("{0}-{1}.WebP", identifier, device)));
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
