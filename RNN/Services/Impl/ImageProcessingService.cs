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
        private Dictionary<int, string> _breakpoints = new Dictionary<int, string>()
        {
            { 375, "tiny" },
            { 540, "medium" },
            { 720, "large" }
        };

        private IWebHostEnvironment _environment { get; set; }

        public ImageProcessingService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string ProcessFormImage(IFormFile file)
        {
            string identifier = Guid.NewGuid().ToString();
            string uploadPath = Path.Combine(_environment.WebRootPath, "images", "uploads");

            ResizeImageToMultipleViewSizes(file, uploadPath, identifier);

            return identifier;
        }

        private void ResizeImageToMultipleViewSizes(IFormFile file, string uploadPath, string identifier)
        {
            using (MagickImage image = new MagickImage(file.OpenReadStream()))
            {
                foreach(var entry in _breakpoints)
                {
                    if(image.Width > entry.Key)
                    {
                        Save(image.Clone(), entry.Value, uploadPath, identifier, MagickFormat.WebP, entry.Key);
                        Save(image.Clone(), entry.Value, uploadPath, identifier, MagickFormat.Jpg, entry.Key);
                    }
                    else
                    {
                        Save(image.Clone(), entry.Value, uploadPath, identifier, MagickFormat.WebP);
                        Save(image.Clone(), entry.Value, uploadPath, identifier, MagickFormat.Jpg);
                    }
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

            optimizer.LosslessCompress(file);
        }
    }
}
