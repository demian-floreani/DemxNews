using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RNN.Controllers.Common
{
    public class BaseController : Controller
    {
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public BaseController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var controllerActionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;

            string uniquePage = String.Join(    "-", 
                                                controllerActionDescriptor.ControllerName,
                                                controllerActionDescriptor.ActionName);

            var cssPage = String.Concat(uniquePage, ".min.css");

            ViewData["Page"] =  _hostingEnvironment.IsDevelopment() ?
                                cssPage :                           // development
                                String.Concat("prod-", cssPage);    // production

            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
        }
    }
}