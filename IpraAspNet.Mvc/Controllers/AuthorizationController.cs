using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.AuthenticationService;
using ServiceLayer.AuthorizeService.Interface;
using ServiceLayer.UserService.Interface;
using System.DirectoryServices.Protocols;
using System.Security.Claims;

namespace IpraAspNet.Mvc.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILdapAuthenticationService _ldapService;

        public AuthorizationController(ILdapAuthenticationService ldapService, IUserService userService)
        {
            _userService = userService;
            _ldapService = ldapService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("User was not found in DB", "Такой пользователь не существует");
                return BadRequest(model);
            }

            try
            {
                var claimsPrincipal = await _ldapService.GetClaimsPrincipalAsync(model);

                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);

                return RedirectToAction("Index", "Admin");
            }
            catch (LdapException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
    }
}
