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
            if (ModelState.IsValid && await _userService.IsExistAsync(model.Login))
            {
                try
                {
                    if(_ldapService.IsAdExist(model))
                    {
                        var user = await _userService.GetUserAsync(model.Login);
                        
                        await HttpContext.SignInAsync("CookieAuthentication", _ldapService.GetClaimsPrincipal(user));

                        return RedirectToAction("Index", "Admin");
                    }
                    ModelState.AddModelError("User was not found in AD", "Неверный логин или пароль");
                    return View(model);
                }
                catch (LdapException)
                {
                    ModelState.AddModelError("incorrect login or password", "Неверный логин или пароль");
                    return View(model);
                }
                catch (Exception)
                {
                    return View(model);
                }

            }
            ModelState.AddModelError("User was not found in DB", "Такой пользователь не существует");
            return View(model);
        }
    }
}
