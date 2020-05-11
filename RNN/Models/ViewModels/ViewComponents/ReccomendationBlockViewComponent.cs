using Microsoft.AspNetCore.Mvc;
using RNN.Models.ViewModels.Data;
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
        public string Img { get; set; }

        public static ReccomendationBlockViewComponent ToViewModel(BasicArticle model)
        {
            var component = new ReccomendationBlockViewComponent();

            component.Slug = model.Slug;
            component.HeadLine = model.HeadLine;
            component.Img = model.Img;

            return component;
        }

        public async Task<IViewComponentResult> InvokeAsync(ReccomendationBlockViewComponent component)
        {
            return View(component);
        }
    }
}
