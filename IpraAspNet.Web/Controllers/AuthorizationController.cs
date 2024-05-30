using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IpraAspNet.Application.AuthenticationService;
using IpraAspNet.Application.AuthorizeService.Interface;
using IpraAspNet.Application.UserService.Interface;
using System.DirectoryServices.Protocols;

namespace IpraAspNet.Web.Controllers
{
    public class AuthorizationController(ILdapAuthenticationService ldapService, IUserService userService)
        : Controller
    {
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
                var claimsPrincipal = await ldapService.GetClaimsPrincipalAsync(model);

                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                if (ex is not LdapException) return View(model);
                ModelState.AddModelError("error", ex.Message);
                return View(model);
            }
        }
    }
}
