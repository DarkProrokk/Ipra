using DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;
using ServiceLayer.IpraService.Concrete;
using ServiceLayer.UserService;
using ServiceLayer.UserService.Concrete;

namespace IpraAspNet.Mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GetDataApiController(IpraContext context): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetDataTest([FromBody]IpraSortFilterPageOptions formData)
        {
            var ipraService = new ListIpraService(context);
            var data = await ipraService.SortFilterPage(formData).ToListAsync();
            return Ok(new JsonResult(new IpraListCombinedDto(formData, data)));
        }
    }
}
