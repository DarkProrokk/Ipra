using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.IpraService;
using IpraAspNet.Application.UserService;
using IpraAspNet.Application.Interfaces;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Application.Context;
using IpraAspNet.Application.Services.IpraService;
using IpraAspNet.Application.Services.IpraService.Models;
using IpraAspNet.Application.Services.IpraService.QueryObject;
using IpraAspNet.Application.Services.UserService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace IpraAspNet.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GetDataApiController(
        IIpraService ipraService, IUserService userService): ControllerBase
    {
        [HttpGet]
        [Route("users/all")]
        public IActionResult GetUsersList([FromQuery]UsersFilterOptions filterOptions, [FromQuery] UsersPagingOptions pagingOptions)
        {
            //Получаем список пользователей отсортированный и отфильтрованый в соответствии с options
            var data =  userService.GetSortedFilteredPage(pagingOptions, filterOptions);

            return Ok(new JsonResult(data));
        }

        [HttpGet]
        [Route("ipra/all/")]
        public IActionResult GetData([FromQuery]IpraFilterOptions filterOptions, [FromQuery] IpraPagingOptions pagingOptions)
        {
            try
            {
                var data = ipraService.SortFilterPage(filterOptions, pagingOptions).ToArray();
                if (data.IsNullOrEmpty()) return NotFound();
                return Ok(new JsonResult(new {data = data}));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound($"is not correct value for {e.ParamName}");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("ipra/get/")]
        public IActionResult GetIpraById([FromQuery]int id)
        {
            return Ok(ipraService.GetById(id));
        }
    }

    
}
