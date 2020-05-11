using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RNN.Controllers.Common;
using RNN.Models;
using RNN.Models.ViewModels.Pages;
using RNN.Models.ViewModels.ViewComponents;
using RNN.Services;
using RNN.Services.Impl;

namespace RNN.Controllers
{
    [AllowAnonymous]
    public class ArticleController : BaseController
    {
        private readonly ITopicService _topicService;
        private readonly IArticleService _articleService;

        public ArticleController(
            IWebHostEnvironment environment,
            IArticleService articleService,
            ITopicService topicService) :base(environment)
        {
            _topicService = topicService;
            _articleService = articleService;
        }

        /// <summary>
        /// Display an article
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [Route("article/{slug}", Name = "display")]
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute] string slug)
        {
            //var user = User.Identity.IsAuthenticated ? (await _userManager.GetUserAsync(HttpContext.User)).Id : null;

            var article = await _articleService.GetArticleBySlugAsync(slug);

            //await _entryService.IncreasePageViews(article);

            ViewData["Title"] = article.HeadLine;
            ViewData["Description"] = article.Paragraph;
            ViewData["OGImage"] = string.Concat("https://www.renegadenews.net/images/uploads/", article.Img);
            ViewData["OGUrl"] = string.Concat("https://www.renegadenews.net/article/", article.Slug);
            ViewData["IncludeDisqus"] = true;

            var topics = article
                .EntryToTopics
                .Select(et => et.Topic);

            DisplayArticle model = new DisplayArticle()
            {
                Article = article,
                Topics = topics
            };

            //model.ViewModelData.Add("IsAuthor", user != null ? user == article.ApplicationUserId : false);
            model.ViewModelData.Add("IsAuthor", false);

            return View("Index", model);
        }

        /// <summary>
        /// Load reccomendations for an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("article/{id}/reccomendations")]
        public async Task<IActionResult> GetReccomendations(
            [FromRoute] int id)
        {
            var topics = _articleService.GetArticleTopics(id);

            var reccomendations = _articleService.GetReccomendedArticlesAsync(
                (await topics).Select(t => t.Id).ToList(),
                id);

            var model = (await reccomendations)
                .Select(r => ReccomendationBlockViewComponent.ToViewModel(r))
                .ToList();

            return PartialView("ReccomendationsPartial", model);
        }

        /// <summary>
        /// Get articles by topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("articles/topic/{topicId}", Name = "topiclist")]
        public async Task<IActionResult> GetByTopic(
            [FromRoute] int topicId)
        {
            var topic = await _topicService.GetById(topicId);

            ViewData["Topic"] = topic.Name;
            ViewData["Title"] = topic.Name;
            ViewData["Description"] = "Latest " + topic.Name + " news & opinions from Renegade News";

            var list = _articleService.GetArticlesByTopicAsync(topicId);

            return View("Topic", (await list).Select(e => HorizontalMediumBlockViewComponent.ToViewModel(e, false)).ToList());
        }
    }
}