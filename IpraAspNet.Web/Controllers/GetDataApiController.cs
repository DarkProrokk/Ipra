using IpraAspNet.Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.IpraService;
using IpraAspNet.Application.IpraService.Concrete;
using IpraAspNet.Application.UserService;
using IpraAspNet.Application.UserService.Interface;

namespace IpraAspNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GetDataApiController(
        IUserService userService,
        IpraContext context): ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> GetData([FromBody]IpraSortFilterPageOptions formData)
        {
            var ipraService = new ListIpraService(context);
            var data = await ipraService.SortFilterPage(formData).ToListAsync();
            return Ok(new JsonResult(new IpraListCombinedDto(formData, data)));
        }

        [HttpPost]
        public async Task<IActionResult> GetUsersList([FromBody]UsersSortFilterPageOptions formData)
        {
            //Получаем список пользователей отсортированный и отфильтрованый в соответствии с options
            var data = await userService.GetSortedFilteredPage(formData).ToListAsync();
            return new JsonResult(new { data = new UsersListCombinedDto(formData, data) });
        }
    }

    
}
