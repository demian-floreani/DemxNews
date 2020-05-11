using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RNN.Controllers.Common;
using RNN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Controllers
{
    [Authorize]
    public class TopicController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ITopicService _topicService;

        public TopicController(
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment,
            ITopicService topicService) : base(hostingEnvironment)
        {
            _configuration = configuration;
            _topicService = topicService;
        }

        [Route("topics/list")]
        [HttpGet]
        public IActionResult Get()
        {
            ViewData["Url"] = _configuration["SiteUrl"];

            var topics = _topicService.GetAllTopics();

            return View("List", topics);
        }

    }
}
