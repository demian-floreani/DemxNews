using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class GroupingViewComponent : ViewComponent
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public IEnumerable<RowViewComponent> Grid { get; set; }
        //public IEnumerable<RowViewComponent> RightGrid { get; set; }

        public static GroupingViewComponent ToViewModel(GroupingViewModel model)
        {
            return new GroupingViewComponent()
            {
                Name = model.Name,
                Title = model.Title,
                Grid = model.Grid,
                //RightGrid = model.RightGrid
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(GroupingViewComponent component)
        {
            return View(component);
        }
    }
}
