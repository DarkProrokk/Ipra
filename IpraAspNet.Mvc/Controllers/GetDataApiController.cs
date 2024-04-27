using DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;
using ServiceLayer.IpraService.Concrete;
using ServiceLayer.UserService;
using ServiceLayer.UserService.Interface;

namespace IpraAspNet.Mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GetDataApiController(
        IUserService userService,
        IpraContext context): ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> GetDataTest([FromBody]IpraSortFilterPageOptions formData)
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
