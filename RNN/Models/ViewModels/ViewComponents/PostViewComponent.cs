using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class PostViewComponent : ViewComponent
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Topics { get; set; }
        
        public async Task<IViewComponentResult> InvokeAsync(PostViewComponent component)
        {
            return View(component);
        }
    }
}
