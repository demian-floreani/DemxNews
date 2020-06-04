using Microsoft.AspNetCore.Mvc;
using RNN.Models.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class FeaturedBlockViewComponent : ViewComponent
    {
        public string Slug { get; set; }
        public string HeadLine { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Topic { get; set; }
        public string Caption { get; set; }

        public static FeaturedBlockViewComponent ToViewModel(BasicArticle model)
        {
            return new FeaturedBlockViewComponent()
            {
                Slug = model.Slug,
                HeadLine = model.HeadLine,
                Paragraph = model.Paragraph,
                Img = model.Img,
                Topic = model.PrimaryTopic,
                Caption = model.Caption
            };
        }

        public IViewComponentResult Invoke(FeaturedBlockViewComponent component)
        {
            return View(component);
        }
    }
}
