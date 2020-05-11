using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace RNN.Controllers.Common
{
    public abstract class BaseController : Controller
    {
        protected IWebHostEnvironment _hostingEnvironment { get; set; }

        public BaseController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var controllerActionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;

            string uniquePage = String.Concat(
                controllerActionDescriptor.ControllerName, 
                "-", 
                controllerActionDescriptor.ActionName);

            var cssPage = String.Concat(uniquePage, ".min.css");

            ViewData["Page"] =  _hostingEnvironment.IsDevelopment() ?
                                cssPage :                           // development
                                String.Concat("prod-", cssPage);    // production

            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;

            if (Request.Cookies["ShowModal"] == null)
            {
                ViewData["ShowModal"] = true;
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append("ShowModal", "false", option);
            }

            ViewData["IncludeJQuery"] = false;
            ViewData["IncludeDisqus"] = false;
        }
    }
}