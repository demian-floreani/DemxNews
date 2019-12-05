using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNN.Models;
using RNN.Models.ViewModels.ViewComponents;

namespace RNN.Controllers
{
    public class HomeController : Controller
    {
        private readonly RNNContext _context;

        public HomeController(RNNContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewData["Controller"] = String.Concat(/*"prod-", */this.ControllerContext.ActionDescriptor.ControllerName, ".min.css");

            Models.ViewModels.IndexViewModel viewModel = new Models.ViewModels.IndexViewModel()
            {
                // get topics with most mentions
                Trending = _context.EntryToTopics
                    .OrderByDescending(pt => pt.EntryId)
                    .Take(10)
                    .Include(pt => pt.Topic)
                    .GroupBy(pt => pt.Topic)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .Take(5)
                    .ToList()
            };

            // layout for articles
            var layout = new List<int>() { 9, 48, 3, 48,
                                           5, 48, 24, 7, 7, 48 };
                                           //24, 7, 7, 48, 5, 48 };
            
            var groupings = _context.Groupings.OrderBy(group => group.Rank);

            List<GroupingViewComponent> groupingViews = new List<GroupingViewComponent>();

            foreach(Grouping grouping in groupings)
            {
                var articles = _context.Entries
                    .Where(a => a.GroupingId == grouping.Id)
                    .Where(a => a.Rank != 0)
                    .Include(a => a.Title)
                    .Include(a => a.Author)
                    .Include(a => a.EntryToTopics)
                    .ThenInclude(at => at.Topic)
                    .OrderByDescending(a => a.Rank);
                
                groupingViews.Add(GroupingViewComponent.ToViewModel(new Models.ViewModels.GroupingViewModel()
                {
                    Title = grouping.Type,
                    Name = grouping.Name,
                    Grid = ArrangeArticles(articles, layout)
                }));
            }

            viewModel.Groupings = groupingViews;
              
            return View("Index", viewModel);
        }

        public List<RowViewComponent> ArrangeArticles(IEnumerable<Entry> articles, List<int> layout)
        {
            Stack<Entry> stack = new Stack<Entry>(articles);

            List<RowViewComponent> rows = new List<RowViewComponent>();
            List<ColumnViewComponent> columns = new List<ColumnViewComponent>();

            List<ViewComponent> components = new List<ViewComponent>();
            bool filledColumn = false;
            int currentLength = 0;
            bool stacking = false;
            int maxWidth = 0;
            bool loop = true;

            for(int i = 0; i < layout.Count() && loop; ++i)
            {
                var width = layout[i];

                switch (width)
                {
                    case 48:
                        filledColumn = true;
                        break;

                    case 24:
                        stacking = true;
                        break;

                    case 9:
                    {
                        Entry article = null;
                        if (stack.TryPop(out article))
                        {
                            components.Add(HorizontalLargeBlockViewComponent.ToViewModel(article, columns.Count > 0));

                            if (width > maxWidth)
                                maxWidth = width;
                        }
                        else
                        {
                            loop = false;
                        }
                    } break;

                    case 6:
                    case 8:
                    case 3:
                    case 5:
                    case 7:
                    case 4:
                    {
                        Entry article = null;
                        if (stack.TryPop(out article))
                        {
                            components.Add(stacking ? (ViewComponent) HorizontalMediumBlockViewComponent.ToViewModel(article, columns.Count > 0) : 
                                                                      VerticalBlockViewComponent.ToViewModel(article, columns.Count > 0));

                            if (width > maxWidth)
                                maxWidth = width;
                        }
                        else
                        {
                            loop = false;
                        }
                    } break;
                }

                if (filledColumn)
                {
                    columns.Add(new ColumnViewComponent()
                    {
                        Width = maxWidth,
                        Components = components
                    });

                    currentLength += maxWidth;

                    components = new List<ViewComponent>();
                    filledColumn = false;
                    maxWidth = 0;
                    stacking = false;
                }

                if (currentLength >= 12)
                {
                    rows.Add(new RowViewComponent()
                    {
                        Columns = columns
                    });

                    columns = new List<ColumnViewComponent>();
                    currentLength = 0;
                }
            }

            if (columns.Count > 0)
            {
                rows.Add(new RowViewComponent()
                {
                    Columns = columns
                });
            }

            return rows;
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
