using DataLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;
using ServiceLayer.IpraService.Concrete;
using ServiceLayer.IpraService.Models;

namespace IpraAspNet.Mvc.Controllers
{
    public class GetDataApiController(IpraContext context): Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetDataTest(IpraSortFilterPageOptions formData)
        {
            
            var ipraService = new ListIpraService(context);
            var ipraList = await ipraService.SortFilterPage(formData).ToListAsync();
            return Json(new IpraListCombinedDto(formData, ipraList));
        }
    }
}
