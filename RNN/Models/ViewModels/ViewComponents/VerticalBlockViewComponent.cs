using Microsoft.AspNetCore.Mvc;
using RNN.Models.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class VerticalBlockViewComponent : ViewComponent
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public bool HasBorder { get; set; }

        public static VerticalBlockViewComponent ToViewModel(BasicArticle model, bool hasBorder)
        {
            return new VerticalBlockViewComponent()
            {
                Slug = model.Slug,
                HeadLine = model.HeadLine,
                Paragraph = model.Paragraph,
                Img = model.Img,
                Topic = model.PrimaryTopic,
                HasBorder = hasBorder
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(VerticalBlockViewComponent component)
        {
            return View(component);
        }
    }
}
