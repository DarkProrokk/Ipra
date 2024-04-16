using System.Diagnostics;
using DataLayer.Context;
using DataLayer.QueryObjects;
using Microsoft.AspNetCore.Mvc;
using IpraAspNet.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;
using ServiceLayer.IpraService.Concrete;
using ServiceLayer.IpraService.QueryObject;

namespace IpraAspNet.Mvc.Controllers;

public class HomeController(ILogger<HomeController> logger, IpraContext context) : Controller
{
    
    public async Task<IActionResult> Index(SortFilterPageOptions<IpraFilterBy> options)
    {
        var listService = new ListIpraService(context);
        var ipraList = await listService.SortFilterPage(options).ToListAsync();
        return View(new IpraListCombinedDto(options, ipraList));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}