using IpraAspNet.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.AuthenticationService;
using ServiceLayer.AuthorizeService.Interface;
using ServiceLayer.IpraService;
using ServiceLayer.UserService;
using ServiceLayer.UserService.Interface;

using System.Diagnostics;

namespace IpraAspNet.Mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IUserService _userService;

        public AdminController(ILogger<AdminController> logger, IUserService userService)
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
            //Получаем список пользователей отсортированный и отфильтрованый в соответствии с options
            var usersList = await _userService.GetSortedFilteredPage(options).ToListAsync();
            return new JsonResult(new { data = new UsersListCombinedDto(options, usersList) });
            //return new JsonResult(new { data = usersList, columnsMapping = columnsMapping });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
