using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class RowViewComponent : ViewComponent
    {
        public IEnumerable<ColumnViewComponent> Columns { get; set; }
        public string CssClass { get; set; }
        
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RowViewComponent> rows)
        {
            return View(rows);
        }
    }
}
