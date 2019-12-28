using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Topic> Trending { get; set; }
        public IEnumerable<GroupingViewComponent> Groupings { get; set; }
    }
}  
