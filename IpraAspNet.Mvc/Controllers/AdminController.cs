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

        public IActionResult Index(UsersSortFilterPageOptions options)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
