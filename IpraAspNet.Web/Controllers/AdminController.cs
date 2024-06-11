using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.AuthenticationService;
using IpraAspNet.Application.AuthorizeService.Interface;
using IpraAspNet.Application.IpraService;
using IpraAspNet.Application.UserService;
using IpraAspNet.Application.Interfaces;

using System.Diagnostics;
using IpraAspNet.Web.Models;

namespace IpraAspNet.Web.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
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
