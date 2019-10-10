using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class ColumnViewComponent : ViewComponent
    {
        public int Width { get; set; }
        public IEnumerable<RowViewComponent> Rows { get; set; }
        public IEnumerable<ViewComponent> Components { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(ColumnViewComponent component)
        {
            return View(component);
        }
    }
}
