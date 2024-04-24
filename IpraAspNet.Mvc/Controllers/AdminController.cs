using IpraAspNet.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.AuthentificationService;
using ServiceLayer.AuthorizeService.Abstract;
using ServiceLayer.IpraService;
using ServiceLayer.UserService;

using ServiceLayer.UserService.Interface;

using ServiceLayer.UserService.Abstract;
using ServiceLayer.UserService.Helpers;

using System.Diagnostics;

namespace IpraAspNet.Mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IUserService _userService;
        private readonly ILdapAuthentificationService _ldapService;

        public AdminController(ILogger<AdminController> logger, IUserService userService, ILdapAuthentificationService ldapService)
        {
            _logger = logger;
            _userService = userService;
            _ldapService = ldapService;
        }

        public IActionResult Index(UsersSortFilterPageOptions options)
        {
            _ldapService.CheckAuthenticate(new AuthModel { Login = "GolikovVI", Password = "FBs2iY86At35"});
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserList(UsersSortFilterPageOptions options)
        {

            var columnsMapping = new Dictionary<string, string>
            {
                { "id", "id" },
                { "userName", "Логин" },
                { "userRoleUsers", "Роли" },
                { "surname", "Фамилия" },
                { "name", "Имя" },
                { "patronymic", "Отчество" },
                { "post", "Должность" },
                { "userMOUsers", "МО" },
            };
            
            var usersList = await _userService.GetSortedFilteredPage(options).ToListAsync();
            //return new JsonResult(new { data = new UsersListCombinedDto(options, usersList), columnsMapping });
            return new JsonResult(new { data = usersList, columnsMapping = columnsMapping });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
