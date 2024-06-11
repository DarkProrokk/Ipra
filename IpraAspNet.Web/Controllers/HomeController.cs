using Microsoft.AspNetCore.Mvc;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Domain.QueryObjects;


namespace IpraAspNet.Web.Controllers;

public class HomeController(IIpraRepository repository) : Controller
{
    public IActionResult Index()
    {
        // try
        // {
        //     var listService = new IpraService(repository);
        //     var ipraList = listService.SortFilterPage(options);
        //     return View(new IpraListCombinedDto(options, ipraList));
        // }
        // catch (ArgumentOutOfRangeException ex)
        // {
        //     return NotFound();
        // }
        return View();
    }

    public IActionResult Test()
    {
        PagingOptions options = new PagingOptions();
        return View(options);
    }


    public IActionResult TestRepo()
    {
        return Redirect($"Home/Index/");
    }
}