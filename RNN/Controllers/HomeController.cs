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
                Trending = _context.ArticleToTopics
                    .OrderByDescending(pt => pt.ArticleId)
                    .Take(10)
                    .Include(pt => pt.Topic)
                    .GroupBy(pt => pt.Topic)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .Take(5)
                    .ToList()
            };

            // featured editorials
            var editorials = _context.Editorials
                .Include(e => e.Author)
                .Include(e => e.Title)
                .Where(e => e.IsFeatured == true)
                .ToList();
            
            // featured posts
            var posts = _context.Posts
                    .Where(p => p.IsFeatured)
                    .Include(p => p.ArticleToTopics)
                    .ThenInclude(pt => pt.Topic)
                    .OrderByDescending(p => p.Date)
                    .ToList();

            var news = _context.News
                .Include(o => o.ArticleToTopics)
                .ThenInclude(ot => ot.Topic)
                .Include(o => o.Author)
                .Include(o => o.Title)
                .Where(o => o.IsFeatured == true)
                .ToList();

            var opinions = _context.Opinions
                .Include(o => o.ArticleToTopics)
                .ThenInclude(ot => ot.Topic)
                .Include(o => o.Author)
                .Include(o => o.Title)
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
                            Components = posts.Select(p => HorizontalSmallBlockViewComponent.ToViewModel(p))
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
                            Components = new List<HorizontalLargeBlockViewComponent>()
                            {
                                HorizontalLargeBlockViewComponent.ToViewModel(editorials.First())
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
                        Components = new List<VerticalBlockViewComponent>()
                        {
                            VerticalBlockViewComponent.ToViewModel(o)
                        }
                    })
                },
                new RowViewComponent()
                {
                    Columns = new List<ColumnViewComponent>()
                    {
                        new ColumnViewComponent()
                        {
                            Width = 8,
                            Rows = new List<RowViewComponent>()
                            {
                                new RowViewComponent()
                                {
                                    Columns = new List<ColumnViewComponent>() 
                                    {
                                        new ColumnViewComponent()
                                        {
                                            Width = 12,
                                            Components = new List<HorizontalMediumBlockViewComponent>()
                                            {
                                                HorizontalMediumBlockViewComponent.ToViewModel(editorials[1])
                                            }
                                        }
                                    }
                                },
                                new RowViewComponent()
                                {
                                    Columns = new List<ColumnViewComponent>() 
                                    {
                                        new ColumnViewComponent()
                                        {
                                            Width = 12,
                                            Components = new List<HorizontalMediumBlockViewComponent>()
                                            {
                                                HorizontalMediumBlockViewComponent.ToViewModel(editorials[1])
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new ColumnViewComponent()
                        {
                            Width = 4,
                            Components = new List<VerticalBlockViewComponent>()
                            {
                                VerticalBlockViewComponent.ToViewModel(opinions.First())
                            }
                        }
                    }
                }
            };

            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            //  //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
            //  \\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
            Grouping first = _context.Groupings.FirstOrDefault(g => g.Rank == 1);
         
            var n = _context.News.Where(o => o.GroupingId == first.Id);
            


            //var grid = new List<RowViewComponent>();
            //grid.Add(BuildGrid(_context.Subjects.FirstOrDefault(s => s.Rank == 1)));
            //grid.Add(BuildGrid(_context.Subjects.FirstOrDefault(s => s.Rank == 2)));


//            viewModel.Grid = grid;

            return View("Index", viewModel);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the subject id</param>
        /// <returns></returns>
        //private RowViewComponent BuildGrid(Grouping rank)
        //{
            // find the topics linked to the subject
            //var topics = _context.SubjectToTopics
            //    .Where(st => st.SubjectId == rank.Rank)
            //    .Include(st => st.Topic)
            //    .Select(st => st.Topic)
            //    .ToList();

            //var posts = _context.Posts
            //    .Include(p => p.ArticleToTopics)
            //    .Where(p => p.ArticleToTopics.Any(pt => topics.FirstOrDefault(t => t.Id == pt.TopicId) != null))
            //    .ToList();

            //var opinions = _context.Opinions
            //    .Include(p => p.ArticleToTopics)
            //    .Where(p => p.ArticleToTopics.Any(ot => topics.FirstOrDefault(t => t.Id == ot.TopicId) != null))
            //    .ToList();

            //var row = new RowViewComponent()
            //{
            //    Columns = new List<ColumnViewComponent>()
            //    {
            //        //new ColumnViewComponent()
            //        //{
            //        //    Width = 2,
            //        //    Rows = null,
            //        //    Components = new List<ViewComponent>() { new TextViewComponent() { Text = rank.Name, SpanCssClass = "subject-sub-title" } }
            //        //},
            //        new ColumnViewComponent()
            //        {
            //            Width = 6,
            //            Rows = null,
            //            Components = posts.Select(p => new PostViewComponent() { Title = p.HeadLine, Url = p.Url, Topics = p.ArticleToTopics.Select(pt => pt.Topic.Name) })
            //        },
            //        new ColumnViewComponent()
            //        {
            //            Width = 6,
            //            Rows = new List<RowViewComponent>()
            //            {
            //                new RowViewComponent()
            //                {
            //                    Columns = ArrangeComponentsInColumns(opinions.Select(o => new OpinionViewComponent(){ Title = o.HeadLine, Img = o.Img, Paragraph = o.Paragraph }))
            //                }
            //            }
            //        }
            //    }
            //};
            
        //    return row;
        //}

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
