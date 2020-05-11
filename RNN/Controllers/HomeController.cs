using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNN.Controllers.Common;
using RNN.Data.Repositories;
using RNN.Models.ViewModels.Data;
using RNN.Models.ViewModels.Pages;
using RNN.Models.ViewModels.ViewComponents;
using RNN.Services;
using RNN.Services.Impl;

namespace RNN.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IArticleService _articleService;

        public HomeController(  IArticleService articleService,
                                IWebHostEnvironment environment) : base (environment)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            ViewData["Title"] = "Populist News & Opinion from Renegade News";
            ViewData["Description"] = "Latest news, populist opinion and analysis from Renegade News";
            
            var layout = new List<int>() { 
                9, 3,
                5, 7, 7,
                7, 7, 5,
                5, 7, 7,
                7, 7, 5,
                5, 7, 7 };

            var groupings = new List<int>()
            {
                5, 6, 6
            };

            var trending = (await _articleService.GetHeadlineTopics(5))
                .GroupBy(t => t)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();

            var groups = GroupArticles(
                await _articleService.GetHeadlineArticles(layout.Count()), 
                groupings, 
                layout);

            HomeViewModel model = new HomeViewModel()
            {
                Trending = trending,
                Groupings = groups
            };

            return View("Index", model);
        }

        private static List<GroupingViewComponent> GroupArticles(
            List<BasicArticle> entries, 
            List<int> groupings, 
            IEnumerable<int> layout)
        {
            List<GroupingViewComponent> groupingViewComponents = new List<GroupingViewComponent>();

            List<RowViewComponent> rows = new List<RowViewComponent>();

            int currWidth = 0;
            List<ViewComponent> components = new List<ViewComponent>();
            List<ColumnViewComponent> columns = new List<ColumnViewComponent>();

            int i = 0, j = 0, group = 0;

            foreach(var block in layout)
            {
                switch(block)
                {
                    case 3:
                        columns.Add(new ColumnViewComponent()
                        {
                            Width = block,
                            Components = new List<ViewComponent>() { VerticalNarrowBlockViewComponent.ToViewModel(entries[i], columns.Count > 0) },
                            Rows = null
                        });

                        currWidth += block;
                        break;

                    case 9:
                        columns.Add(new ColumnViewComponent() {
                            Width = block,
                            Components = new List<ViewComponent>() { HorizontalLargeBlockViewComponent.ToViewModel(entries[i], columns.Count > 0) },
                            Rows = null
                        });

                        currWidth += block;
                        break;

                    case 5:
                    case 6:
                        columns.Add(new ColumnViewComponent()
                        {
                            Width = block,
                            Components = new List<ViewComponent>() { VerticalBlockViewComponent.ToViewModel(entries[i], columns.Count > 0) },
                            Rows = null
                        });

                        currWidth += block;
                        break;

                    case 7:
                        if(components.Any())
                        {
                            components.Add(HorizontalMediumBlockViewComponent.ToViewModel(entries[i], columns.Count > 0));

                            columns.Add(new ColumnViewComponent()
                            {
                                Width = block,
                                Components = components,
                                Rows = null
                            });

                            currWidth += block;
                            components = new List<ViewComponent>();
                        }
                        else
                        {
                            components.Add(HorizontalMediumBlockViewComponent.ToViewModel(entries[i], columns.Count > 0));
                        }
                        break;
                }

                if(currWidth >= 12)
                {
                    rows.Add(new RowViewComponent()
                    {
                        Columns = columns
                    });

                    currWidth = 0;
                    columns = new List<ColumnViewComponent>();
                }

                ++i;
                ++j;

                if(j == groupings[group])
                {
                    groupingViewComponents.Add(GroupingViewComponent.ToViewModel(new GroupingViewModel() { Grid = rows }));
                    rows = new List<RowViewComponent>();

                    j = 0;
                    ++group;
                }
            }

            return groupingViewComponents;
        }

        //private static List<GroupingViewComponent> GroupArticles(IEnumerable<Entry> entries, List<List<int>> layouts)
        //{
        //    List<GroupingViewComponent> groupingViews = new List<GroupingViewComponent>();

        //    LinkedList<Entry> list = new LinkedList<Entry>(entries);
        //    List<Entry> splits = new List<Entry>();

        //    var head = list.First;
        //    int i = 0;
        //    var layout = layouts[0];
        //    var layoutSize = layout.Count(e => e <= 12);

        //    while (head != null)
        //    {
        //        splits.Add(head.Value);
        //        head = head.Next;

        //        // number of elements is higher than current layout size
        //        if (splits.Count == layoutSize || head == null)
        //        {
        //            groupingViews.Add(GroupingViewComponent.ToViewModel(new GroupingViewModel()
        //            {
        //                Grid = ArrangeArticles(splits, layout)
        //            }));

        //            if(head != null && i++ > layouts.Count - 1)
        //            {
        //                break;
        //            }

        //            layout = layouts[i];
        //            layoutSize = layout.Count(e => e <= 12);
        //            splits = new List<Entry>();
        //        }
        //    }

        //    return groupingViews;
        //}

        //public static double RankHalfTime(int rank, DateTime date)
        //{
        //    double magicNum = 1.025;
        //    return (double) rank - (Math.Pow(magicNum, (DateTime.Now - date).TotalHours) - 1d);
        //}

        //private static List<RowViewComponent> ArrangeArticles(IEnumerable<Entry> articles, List<int> layout)
        //{
        //    LinkedList<Entry> list = new LinkedList<Entry>(articles);
        //    var head = list.First;

        //    List<RowViewComponent> rows = new List<RowViewComponent>();
        //    List<ColumnViewComponent> columns = new List<ColumnViewComponent>();

        //    List<ViewComponent> components = new List<ViewComponent>();
        //    bool filledColumn = false;
        //    int currentLength = 0;
        //    bool stacking = false;
        //    int maxWidth = 0;
        //    bool loop = true;
            
        //    for(int i = 0; i < layout.Count() && loop; ++i)
        //    {
        //        if (head != null)
        //        {
        //            var width = layout[i];

        //            switch (width)
        //            {
        //                case 48:
        //                    filledColumn = true;
        //                    break;

        //                case 24:
        //                    stacking = true;
        //                    break;

        //                case 9:
        //                    components.Add(HorizontalLargeBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

        //                    head = head.Next;

        //                    if (width > maxWidth)
        //                        maxWidth = width;
        //                    break;

        //                case 3:
        //                    components.Add(VerticalNarrowBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

        //                    head = head.Next;

        //                    if (width > maxWidth)
        //                        maxWidth = width;
        //                    break;

        //                case 6:
        //                case 8:
        //                case 5:
        //                case 7:
        //                case 4:
        //                    components.Add(stacking ? (ViewComponent)   HorizontalMediumBlockViewComponent.ToViewModel(head.Value, columns.Count > 0) :
        //                                                                VerticalBlockViewComponent.ToViewModel(head.Value, columns.Count > 0));

        //                    head = head.Next;

        //                    if (width > maxWidth)
        //                        maxWidth = width;
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            loop = false;

        //            if(components.Any())
        //                filledColumn = true;
        //        }

        //        if (filledColumn)
        //        {
        //            columns.Add(new ColumnViewComponent()
        //            {
        //                Width = maxWidth,
        //                Components = components
        //            });

        //            currentLength += maxWidth;

        //            components = new List<ViewComponent>();
        //            filledColumn = false;
        //            maxWidth = 0;
        //            stacking = false;
        //        }

        //        if (currentLength >= 12)
        //        {
        //            rows.Add(new RowViewComponent()
        //            {
        //                Columns = columns
        //            });

        //            columns = new List<ColumnViewComponent>();
        //            currentLength = 0;
        //        }
        //    }

        //    if (columns.Count > 0)
        //    {
        //        rows.Add(new RowViewComponent()
        //        {
        //            Columns = columns
        //        });
        //    }

        //    return rows;
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
