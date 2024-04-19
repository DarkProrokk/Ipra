using DataLayer.Context;
using IpraAspNet.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceLayer.IpraService;
using ServiceLayer.UserService;
using ServiceLayer.UserService.Concrete;
using System.Diagnostics;

namespace IpraAspNet.Mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IListUsersService _userService;
        public AdminController(ILogger<AdminController> logger, IListUsersService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index(UsersSortFilterPageOptions options)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserList(UsersSortFilterPageOptions options)
        {
            var columnsMapping = new Dictionary<string, string>
            {
                { "id", "id" },
                { "userName", "логин" },
                { "userRoleUsers", "Роли" },
                { "surname", "Фамилия" },
                { "name", "Имя" },
                { "patronymic", "Отчество" },
                { "post", "Должность" },
                { "userMOUsers", "МО" },
                
            };
            var usersList = await _userService.SortFilterPage(options).ToListAsync();
            return new JsonResult(new { data = new UsersListCombinedDto(options, usersList), columnsMapping });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
