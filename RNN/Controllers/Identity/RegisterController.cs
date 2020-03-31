using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RNN.Controllers.Common;
using RNN.Models.Identity;
using RNN.Models.ViewModels.Identity;

namespace RNN.Controllers.Identity
{
    [AllowAnonymous]
    [Route("Register/")]
    public class RegisterController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(  IHostingEnvironment environment,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager) : base (environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(Register form)
        {
            string returnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = form.Email,
                    Email = form.Email,
                    DisplayName = form.DisplayName
                };

                var result = await _userManager.CreateAsync(user, form.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

            }

            return View("Index");
        }
    }
}