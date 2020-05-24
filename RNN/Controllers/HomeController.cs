using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                5, 7, 7 };    

            var trending = (await _articleService.GetHeadlineTopics(5))
                .GroupBy(t => t)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5)
                .ToList();

            var entries = await _articleService.GetHeadlineArticles(layout.Count());

            var group = GroupArticles(
                entries, 
                layout);

            HomeViewModel model = new HomeViewModel()
            {
                Trending = trending,
                Grouping = group
            };

            return View("Index", model);
        }

        [HttpGet]
        [Route("/home/load/{offset}")]
        public async Task<IActionResult> Load(
            [FromRoute] int offset)
        {
            var entries = await _articleService.GetHeadlineArticles(6, offset);

            var group = GroupArticles(entries, new List<int>() { 7, 7, 5, 5, 7, 7 });

            return PartialView("GroupingPartial", group);
        }

        [HttpGet]
        [Route("/home/footer")]
        public IActionResult Footer()
        {
            return PartialView("FooterPartial");
        }

        private static GroupingViewComponent GroupArticles(
            List<BasicArticle> entries, 
            IEnumerable<int> layout)
        {
            List<RowViewComponent> rows = new List<RowViewComponent>();

            int currWidth = 0;
            List<ViewComponent> components = new List<ViewComponent>();
            List<ColumnViewComponent> columns = new List<ColumnViewComponent>();

            int i = 0;

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
            }

            return GroupingViewComponent.ToViewModel(new GroupingViewModel() { Grid = rows });
        }
    }
}
