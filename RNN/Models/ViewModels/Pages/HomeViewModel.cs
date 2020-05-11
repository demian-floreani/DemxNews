using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Pages
{
    public class HomeViewModel
    {
        public IEnumerable<Topic> Trending { get; set; }
        public IEnumerable<GroupingViewComponent> Groupings { get; set; }
    }
}  
