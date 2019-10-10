using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.ViewComponents
{
    public class EditorialViewComponent : ViewComponent
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Paragraph { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }

        public static EditorialViewComponent ToViewModel(Editorial model)
        {
            return new EditorialViewComponent()
            {
                Url = model.Url,
                Title = model.Title,
                Author = model.Author.Name,
                Paragraph = model.Paragraph,
                Body = model.Body,
                Img = model.Img
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(EditorialViewComponent component)
        {
            return View(component);
        }
    }
}
