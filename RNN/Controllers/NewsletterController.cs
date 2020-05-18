using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RNN.Controllers.Common;
using RNN.Messaging;
using RNN.Models;
using RNN.Services;

namespace RNN.Controllers
{
    public class NewsletterController : BaseController
    {
        private readonly INewsletterService _service;

        public NewsletterController(
            IWebHostEnvironment hostingEnvironment,
            INewsletterService service) : base(hostingEnvironment)
        {
            _service = service;
        }

        [HttpPost]
        public async Task OnPost(
            [FromBody] AddNewsletterRequest request)
        {
            await _service.AddNewsletter(request.Email);
        }
    }
}