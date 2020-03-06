using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class HorizontalSmallBlockViewComponent : ViewComponent
    {
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public string Topic { get; set; }

        public static HorizontalSmallBlockViewComponent ToViewModel(Entry model)
        {
            return new HorizontalSmallBlockViewComponent()
            {
                Url = model.Url,
                HeadLine = model.HeadLine,
                Topic = model.EntryToTopics.Any() ? model.EntryToTopics.First(et => et.IsPrimary).Topic.Name : null
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(HorizontalSmallBlockViewComponent component)
        {
            return View(component);
        }
    }
}
