using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RNN.Controllers.Common;
using RNN.Models;

namespace RNN.Controllers
{
    [AllowAnonymous]
    public class ContactController : BaseController
    {
        readonly private RNNContext _entryRepository;

        public ContactController(
            RNNContext rnnContext,
            IWebHostEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
            _entryRepository = rnnContext;
        }

        [HttpGet]
        [Route("contact/")]
        public IActionResult Get()
        {
            return View("ContactUs");
        }

        [HttpPost]
        public async Task OnPost(
            [FromForm] Message message)
        {
            await _entryRepository.Messages.AddAsync(new Message()
            {
                Name = message.Name,
                Email = message.Email,
                Text = message.Text,
                Date = DateTime.Now
            });

            await _entryRepository.SaveChangesAsync();
        }
    }
}