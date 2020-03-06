using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNN.Models;
using RNN.Models.ViewModels.ViewComponents;

namespace RNN.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly RNNContext _context;

        public HomeController(RNNContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewData["Controller"] = String.Concat(!_environment.IsDevelopment() ? "prod-" : "", this.ControllerContext.ActionDescriptor.ControllerName, ".min.css");

            Models.ViewModels.IndexViewModel viewModel = new Models.ViewModels.IndexViewModel()
            {
                // get topics with most mentions
                Trending = _context.EntryToTopics
                    .OrderByDescending(pt => pt.EntryId)
                    .Take(20)
                    .Include(pt => pt.Topic)
                    .GroupBy(pt => pt.Topic)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .Take(5)
                    .ToList()
            };

            var layouts = new List<List<int>>() 
            {
                new List<int>() { 9, 48, 3, 48, 
                                  5, 48, 24, 7, 7, 48 },
                new List<int>() { 24, 7, 7, 48, 5, 48, 
                                  6, 48, 24, 6, 6, 48 },
                new List<int>() { 24, 7, 7, 48, 5, 48  }
            };

            var articles = _context.Entries
                                   .Include(a => a.EntryToTopics)
                                   .ThenInclude(at => at.Topic)
                                   .ToList();

            viewModel.Groupings = GroupArticles(articles.OrderByDescending(a => RankHalfTime(a.Rank, a.Date)), layouts);

            return View("Index", viewModel);
        }

        public static List<GroupingViewComponent> GroupArticles(IEnumerable<Entry> entries, List<List<int>> layouts)
        {
            List<GroupingViewComponent> groupingViews = new List<GroupingViewComponent>();

            LinkedList<Entry> list = new LinkedList<Entry>(entries);
            List<Entry> splits = new List<Entry>();

            var head = list.First;
            int i = 0;
            var layout = layouts[0];
            var layoutSize = layout.Count(e => e <= 12);

            while (head != null)
            {
                splits.Add(head.Value);
                head = head.Next;

                // number of elements is higher than current layout size
                if (splits.Count == layoutSize || head == null)
                {
                    groupingViews.Add(GroupingViewComponent.ToViewModel(new Models.ViewModels.GroupingViewModel()
                    {
                        Grid = ArrangeArticles(splits, layout)
                    }));

                    if(head != null && i++ > layouts.Count - 1)
                    {
                        break;
                    }

                    layout = layouts[i];
                    layoutSize = layout.Count(e => e <= 12);
                    splits = new List<Entry>();
                }
            }

            return groupingViews;
        }

        public static double RankHalfTime(int rank, DateTime date)
        {
            double magicNum = 1.025;
            return (double) rank - (Math.Pow(magicNum, (DateTime.Now - date).TotalHours) - 1d);
        }

        public static List<RowViewComponent> ArrangeArticles(IEnumerable<Entry> articles, List<int> layout)
        {
            LinkedList<Entry> list = new LinkedList<Entry>(articles);
            var head = list.First;

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
                if (head != null)
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
                            components.Add(HorizontalLargeBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

                            head = head.Next;

                            if (width > maxWidth)
                                maxWidth = width;
                            break;

                        case 3:
                            components.Add(VerticalNarrowBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

                            head = head.Next;

                            if (width > maxWidth)
                                maxWidth = width;
                            break;

                        case 6:
                        case 8:
                        case 5:
                        case 7:
                        case 4:
                            components.Add(stacking ? (ViewComponent)HorizontalMediumBlockViewComponent.ToViewModel(head.Value, columns.Count > 0) :
                                                                        VerticalBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

                            head = head.Next;

                            if (width > maxWidth)
                                maxWidth = width;
                            break;
                    }
                }
                else
                {
                    loop = false;

                    if(components.Any())
                        filledColumn = true;
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
