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
                // get topics with most mentions in latest posts
                Trending = _context.PostToTopics
                    .OrderByDescending(pt => pt.PostId)
                    .Take(10)
                    .Include(pt => pt.Topic)
                    .GroupBy(pt => pt.Topic)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .Take(5)
                    .ToList()
            };
            
            // featured editorial
            var editorial = _context.Editorials.Include(e => e.Author).FirstOrDefault(e => e.IsFeatured == true);
            
            // featured posts
            var posts = _context.Posts
                    .Where(p => p.IsFeatured)
                    .Include(p => p.PostToTopic)
                    .ThenInclude(pt => pt.Topic)
                    .OrderByDescending(p => p.Date)
                    .ToList();

            var opinions = _context.Set<Opinion>()
                .Include(o => o.OpinionToTopic)
                .ThenInclude(ot => ot.Topic)
                .Include(o => o.Author)
                .Where(o => o.IsFeatured == true)
                .ToList();

            viewModel.FeaturedLeftGrid = new List<RowViewComponent>()
            {
                new RowViewComponent()
                {
                    Columns = new List<ColumnViewComponent>()
                    {
                        new ColumnViewComponent()
                        {
                            Width = 12,
                            Rows = null,
                            Components = posts.Select(p => new PostViewComponent()
                            {
                                Url = p.Url,
                                Title = p.Title,
                                Topics = p.PostToTopic.Select(pt => pt.Topic.Name)
                            })
                        }
                    }
                }
            };

            viewModel.FeaturedRightGrid = new List<RowViewComponent>()
            {
                new RowViewComponent()
                {
                    Columns = new List<ColumnViewComponent>()
                    {
                        new ColumnViewComponent()
                        {
                            Width = 12,
                            Components = new List<EditorialViewComponent>()
                            {
                                EditorialViewComponent.ToViewModel(editorial)
                            }
                        }
                    }
                },
                new RowViewComponent()
                {
                    Columns = opinions.Select(o => new ColumnViewComponent()
                        {
                            Width = 4,
                            Rows = null,
                            Components = new List<OpinionViewComponent>()
                            {
                                new OpinionViewComponent()
                                {
                                    Id = o.Id,
                                    Title = o.Title,
                                    Img = o.Img,
                                    Paragraph = o.Paragraph,
                                    Topics = o.OpinionToTopic.Select(ot => ot.Topic.Name)
                                }
                            }
                        })
                }
            };

            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            //var grid = new List<RowViewComponent>();
            //grid.Add(BuildGrid(_context.Subjects.FirstOrDefault(s => s.Rank == 1)));
            //grid.Add(BuildGrid(_context.Subjects.FirstOrDefault(s => s.Rank == 2)));

//            viewModel.Grid = grid;

            return View("Index", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the subject id</param>
        /// <returns></returns>
        private RowViewComponent BuildGrid(Subject rank)
        {
            // find the topics linked to the subject
            var topics = _context.SubjectToTopics
                .Where(st => st.SubjectId == rank.Rank)
                .Include(st => st.Topic)
                .Select(st => st.Topic)
                .ToList();

            var posts = _context.Posts
                .Include(p => p.PostToTopic)
                .Where(p => p.PostToTopic.Any(pt => topics.FirstOrDefault(t => t.Id == pt.TopicId) != null))
                .ToList();

            var opinions = _context.Opinions
                .Include(p => p.OpinionToTopic)
                .Where(p => p.OpinionToTopic.Any(ot => topics.FirstOrDefault(t => t.Id == ot.TopicId) != null))
                .ToList();

            var row = new RowViewComponent()
            {
                CssClass = "subject-section",
                Columns = new List<ColumnViewComponent>()
                {
                    new ColumnViewComponent()
                    {
                        Width = 2,
                        Rows = null,
                        Components = new List<ViewComponent>() { new TextViewComponent() { Text = rank.Name, SpanCssClass = "subject-sub-title" } }
                    },
                    new ColumnViewComponent()
                    {
                        Width = 4,
                        Rows = null,
                        Components = posts.Select(p => new PostViewComponent() { Title = p.Title, Url = p.Url, Topics = p.PostToTopic.Select(pt => pt.Topic.Name) })
                    },
                    new ColumnViewComponent()
                    {
                        Width = 6,
                        Rows = new List<RowViewComponent>()
                        {
                            new RowViewComponent()
                            {
                                Columns = ArrangeComponentsInColumns(opinions.Select(o => new OpinionViewComponent(){ Title = o.Title, Img = o.Img, Paragraph = o.Paragraph }))
                            }
                        }
                    }
                }
            };
            
            return row;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="components"></param>
        /// <param name="itemsPerRow"></param>
        /// <returns></returns>
        private static IEnumerable<ColumnViewComponent> ArrangeComponentsInColumns(IEnumerable<ViewComponent> components, int? itemsPerRow = null)
        {
            List<ColumnViewComponent> columns = new List<ColumnViewComponent>();
            int columnWidth = itemsPerRow != null ? 12 / itemsPerRow.Value : 12 / components.Count();

            foreach(ViewComponent component in components)
            {
                columns.Add(new ColumnViewComponent()
                {
                    Width = columnWidth,
                    Rows = null,
                    Components = new List<ViewComponent>() { component }
                });
            }

            return columns;
        }
    }
}
