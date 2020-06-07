using Microsoft.AspNetCore.Mvc;
using RNN.Models.ViewModels.Common;
using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Pages
{
    public class DisplayArticle : ViewModelBase
    {
        public Entry Article { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
    }
}
