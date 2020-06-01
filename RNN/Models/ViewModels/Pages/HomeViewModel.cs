using RNN.Models.ViewModels.Data;
using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Pages
{
    public class HomeViewModel
    {
        public FeaturedBlockViewComponent Featured { get; set; }
        public IEnumerable<Topic> Trending { get; set; }
        public GroupingViewComponent Grouping { get; set; }
    }
}  
