using DataLayer.Context;
using IpraAspNet.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;
using ServiceLayer.IpraService.Concrete;
using System.Diagnostics;

namespace IpraAspNet.Mvc.Controllers;

public class HomeController(IpraContext context) : Controller
{
    public async Task<IActionResult> Index(IpraSortFilterPageOptions options)
    {
        try
        {
            var listService = new ListIpraService(context);
            var ipraList = await listService.SortFilterPage(options).ToListAsync();
            return View(new IpraListCombinedDto(options, ipraList));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return NotFound();
        }
    }

    public IActionResult Test()
    {
        IpraSortFilterPageOptions options = new IpraSortFilterPageOptions();
        options.SetupTestOfDto();
        return View(options);
    }
}