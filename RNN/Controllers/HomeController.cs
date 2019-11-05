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

            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            var groupings = _context.Groupings.OrderBy(g => g.Rank);

            List<GroupingViewComponent> groupingViews = new List<GroupingViewComponent>();

            foreach(Grouping grouping in groupings)
            {
                var articles = _context.Articles
                    .Where(a => a.GroupingId == grouping.Id)
                    .Include(a => a.Title)
                    .Include(a => a.Author)
                    .Include(a => a.ArticleToTopics)
                    .ThenInclude(at => at.Topic)
                    .OrderBy(a => a.Rank);

                var posts = _context.Posts
                    .Where(p => p.GroupingId == grouping.Id)
                    .Include(p => p.ArticleToTopics)
                    .ThenInclude(pt => pt.Topic)
                    .OrderByDescending(p => p.Date);

                groupingViews.Add(GroupingViewComponent.ToViewModel(new Models.ViewModels.GroupingViewModel()
                {
                    Title = grouping.Type,
                    Name = grouping.Name,
                    Grid = new List<RowViewComponent>()
                    {
                        new RowViewComponent()
                        {
                            Columns = new List<ColumnViewComponent>()
                            {
                                new ColumnViewComponent()
                                {
                                    Width = 4,
                                    Components = posts.Select(p => HorizontalSmallBlockViewComponent.ToViewModel(p))
                                },
                                new ColumnViewComponent()
                                {
                                    Width = 8,
                                    Rows = ArrangeArticles(articles)
                                }
                            }
                        }
                    }
                }));
            }

            viewModel.Groupings = groupingViews;
              
            return View("Index", viewModel);
        }

        public List<RowViewComponent> ArrangeArticles(IEnumerable<Article> articles)
        {
            List<RowViewComponent> rows = new List<RowViewComponent>();
            List<ColumnViewComponent> columns = new List<ColumnViewComponent>();

            List<ViewComponent> components = new List<ViewComponent>();
            bool filledColumn = false;
            int currentLength = 0;

            foreach (Article article in articles)
            {
                switch (article.Width)
                {
                    case 12:
                        {
                            components.Add(HorizontalLargeBlockViewComponent.ToViewModel(article));
                            filledColumn = true;
                        }
                        break;

                    case 4:
                        {
                            components.Add(VerticalBlockViewComponent.ToViewModel(article));
                            filledColumn = true;
                        }
                        break;

                    case 8:
                        {
                            components.Add(HorizontalMediumBlockViewComponent.ToViewModel(article));

                            if (components.Count == 2)
                                filledColumn = true;
                        }
                        break;
                }

                if (filledColumn)
                {
                    columns.Add(new ColumnViewComponent()
                    {
                        Width = article.Width,
                        Components = components
                    });

                    currentLength += article.Width;

                    components = new List<ViewComponent>();
                    filledColumn = false;
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
