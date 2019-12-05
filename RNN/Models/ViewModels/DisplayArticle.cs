using Microsoft.AspNetCore.Mvc;
using RNN.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels
{
    public class DisplayArticle
    {
        public Entry Article { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<HorizontalSmallBlockViewComponent> Reccomendations { get; set; }
    }
}
