using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class ReccomendationBlockViewComponent : ViewComponent
    {
        public string Slug { get; set; }
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public string Img { get; set; }
        //public string Topic { get; set; }

        public static ReccomendationBlockViewComponent ToViewModel(Entry model)
        {
            var component = new ReccomendationBlockViewComponent();

            component.Slug = model.Slug;
            component.Url = model.Url;
            component.HeadLine = model.HeadLine;
            component.Img = model.Img;
            //component.Topic = model.EntryToTopics.Any() ? model.EntryToTopics.First().Topic.Name : null;

            return component;
            //return new ReccomendationBlockViewComponent()
            //{
            //    Slug = model.Slug,
            //    Url = model.Url,
            //    HeadLine = model.HeadLine,
            //    Img = model.Img,
            //    Topic = model.EntryToTopics.Any() ? model.EntryToTopics.First().Topic.Name : null
            //};
        }

        public async Task<IViewComponentResult> InvokeAsync(ReccomendationBlockViewComponent component)
        {
            return View(component);
        }
    }
}
