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
    public class StaticPagesController : BaseController
    {
        public StaticPagesController(
            IWebHostEnvironment environment) : base(environment) { }

        [HttpGet]
        [Route("about/")]
        public async Task<IActionResult> GetAbout()
        {
            return View("About");
        }

        [HttpGet]
        [Route("privacy/")]
        public async Task<IActionResult> GetPrivacy()
        {
            return View("Privacy");
        }
    }
}