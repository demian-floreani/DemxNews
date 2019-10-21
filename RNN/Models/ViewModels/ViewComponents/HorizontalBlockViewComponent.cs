using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class HorizontalBlockViewComponent : ViewComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }

        public static HorizontalBlockViewComponent ToViewModel(Article model)
        {
            return new HorizontalBlockViewComponent()
            {
                Url = model.Url,
                Title = model.Title.Name,
                HeadLine = model.HeadLine,
                Author = model.Author.Name,
                Paragraph = model.Paragraph,
                Img = model.Img,
                Topic = model.ArticleToTopics?.First().Topic.Name
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(HorizontalBlockViewComponent component)
        {
            return View(component);
        }
    }
}
