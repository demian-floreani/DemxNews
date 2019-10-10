using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class TextViewComponent : ViewComponent
    {   
        public string Text { get; set; }
        public string SpanCssClass { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(TextViewComponent component)
        {
            return View(component);
        }
    }
}
