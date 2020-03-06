using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RNN.Models;

namespace RNN.Controllers
{
    public class MessageController : Controller
    {
        private readonly RNNContext _context;
        private readonly IHostingEnvironment _environment;

        public MessageController(RNNContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Route("contribute/")]
        public async Task<IActionResult> Index()
        {
            ViewData["Controller"] = String.Concat(!_environment.IsDevelopment() ? "prod-" : "", this.ControllerContext.ActionDescriptor.ControllerName, ".min.css");

            return View("Index");
        }

        [HttpPost]
        public async Task Create(Message message)
        {
            _context.Messages.Add(new Message() 
            {
                Name = message.Name,
                Email = message.Email,
                Text = message.Text,
                Date = DateTime.Now
            });

            await _context.SaveChangesAsync();
        }
    }
}