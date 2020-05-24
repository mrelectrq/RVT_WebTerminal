using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
using RVT_W_BusinessLayer;
using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Interfaces;
using RVTWebTerminal.Models;

namespace RVTWebTerminal.Controllers
{
    public class AuthController : Controller
    {
        private ISessions session;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            var bl = new BusinessManager();
            session = bl.GetSession();
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //public IActionResult Index()
        //{


        //    //var Claims = new List<Claim>()
        //    //{
        //    //    new Claim(ClaimTypes.Name,"Ion", ClaimTypes.),
        //    //};
        //    //var licenseClaim = new List<Claim>()
        //    //{
        //    //    new Claim(ClaimTypes.Name,"Ion")
        //    //};
        //    //var identity = new ClaimsIdentity(Claims, "Claims");
        //    //var userPrincipal = ClaimsPrincipal(new[] { identity });
        //    //HttpContext.SignInAsync(userPrincipal);

        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.IDNP);
            if (_userManager != null)
            {
                var resultsignin = await _signInManager.PasswordSignInAsync(model.IDNP, model.VnPassword, false, false);
                if (resultsignin.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
            }

            LoginData data = new LoginData();
            data.IDNP = model.IDNP;
            data.VnPassword = model.VnPassword;

            var response = await session.Login(data);
            if (response.Status == true)
            {
                return RedirectToAction("Vote", "User");
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
