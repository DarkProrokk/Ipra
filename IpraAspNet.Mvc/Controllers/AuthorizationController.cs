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
    //todo комментарии + docstring
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILdapAuthentificationService _ldapService;

        public AuthorizationController(ILdapAuthentificationService ldapService, IUserService userService)
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
                    var login = _ldapService.GetAdUserLogin(model);
                    var user = await _userService.GetUserAsync(login);
                    //Todo: Вынести клаймсы в отдельный метод
                    #region Claims
                    var userClaims = new List<Claim>
                    {
                        new Claim("username", user.UserName),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRoleUsers.FirstOrDefault().Role.RoleName.ToString())
                    };

                    var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, _ldapService.GetType().Name));
                    #endregion
                    await HttpContext.SignInAsync("CookieAuthentication", principal);

                    return RedirectToAction("Index", "Admin");
                }
                catch (LdapException ex)
                {
                    var sd = ex.ErrorCode;
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
