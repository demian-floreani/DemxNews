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
    [Route("Login/")]
    public class LoginController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(     IWebHostEnvironment environment, 
                                    SignInManager<ApplicationUser> signInManager) : base(environment)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> OnPost(
            [FromForm] Login form)
        {

            var list = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var returnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(  form.Email,
                                                                        form.Password,
                                                                        form.RememberMe,
                                                                        lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            return View("Index");
        }
    }
}