using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Pages
{
    public class GroupingViewModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public IEnumerable<RowViewComponent> Grid { get; set; }
    }
}
