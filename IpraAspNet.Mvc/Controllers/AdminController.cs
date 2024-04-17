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
    public class AdminController(ILogger<AdminController> logger, IpraContext context) : Controller
    {
        public async Task<IActionResult> Index(UsersSortFilterPageOptions options)
        {
            var listService = new ListUsersService(context);
            var usersList = await listService.SortFilterPage(options).ToListAsync();
            return View(new UsersListCombinadDto(options, usersList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
