using IpraAspNet.Domain.Context;
using IpraAspNet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.IpraService;
using IpraAspNet.Application.IpraService.Concrete;
using System.Diagnostics;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Application.DAL.Abstract;

namespace IpraAspNet.Web.Controllers;

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


    public IActionResult TestRepo()
    {
        return Redirect($"Home/Index/");
    }
}