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
                Save(image.Clone(), "tiny", uploadPath, identifier, MagickFormat.WebP, 375);
                Save(image.Clone(), "tiny", uploadPath, identifier, MagickFormat.Jpg, 375);

                if (image.Width > 540)
                {
                    // create image for medium devices
                    Save(image.Clone(), "medium", uploadPath, identifier, MagickFormat.WebP, 540);
                    Save(image.Clone(), "medium", uploadPath, identifier, MagickFormat.Jpg, 540);
                }
                else
                {
                    Save(image.Clone(), "medium", uploadPath, identifier, MagickFormat.WebP);
                    Save(image.Clone(), "medium", uploadPath, identifier, MagickFormat.Jpg);
                }

                if (image.Width > 720)
                {
                    // create image for large devices
                    Save(image.Clone(), "large", uploadPath, identifier, MagickFormat.WebP, 720);
                    Save(image.Clone(), "large", uploadPath, identifier, MagickFormat.Jpg, 720);
                }
                else
                {
                    Save(image.Clone(), "large", uploadPath, identifier, MagickFormat.WebP);
                    Save(image.Clone(), "large", uploadPath, identifier, MagickFormat.Jpg);
                }
            }
        }

        private void Save(IMagickImage image, string device, string uploadPath, string identifier, MagickFormat format, int? size = null)
        {
            image.Format = format;

            if(size != null)
            {
                image.Resize(new MagickGeometry()
                {
                    Width = size.Value,
                    IgnoreAspectRatio = false
                });
            }

            string path = Path.Combine(uploadPath, String.Format("{0}-{1}.{2}", identifier, device, format.ToString()));

            image.Write(path);

            if(format == MagickFormat.Jpg)
            {
                Compress(path);
            }    
        }

        private static void Compress(string file)
        {
            ImageOptimizer optimizer = new ImageOptimizer()
            {
                OptimalCompression = true,
                IgnoreUnsupportedFormats = true
            };

            optimizer.Compress(file);
        }
    }
}
