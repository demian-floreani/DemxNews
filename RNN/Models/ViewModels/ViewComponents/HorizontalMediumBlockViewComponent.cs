using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class HorizontalMediumBlockViewComponent : ViewComponent
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public bool HasBorder { get; set; }

        public static HorizontalMediumBlockViewComponent ToViewModel(Entry model, bool hasBorder)
        {
            return new HorizontalMediumBlockViewComponent()
            {
                Slug = model.Slug,
                Url = model.Url,
                //Title = model.Title.Name,
                HeadLine = model.HeadLine,
                //Author = model.Author.Name,
                Img = model.Img,
                Topic = model.EntryToTopics.Any() ? model.EntryToTopics.First().Topic.Name : null,
                HasBorder = hasBorder
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(HorizontalMediumBlockViewComponent component)
        {
            return View(component);
        }
    }
}
