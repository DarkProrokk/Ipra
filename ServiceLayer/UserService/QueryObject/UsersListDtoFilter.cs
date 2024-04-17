using ServiceLayer.IpraService.QueryObject;
using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService.QueryObject
{
    public static class UsersListDtoFilter
    {
        public static IQueryable<UsersListDto> FilterUsersBy(this IQueryable<UsersListDto> users)
        {
            return users;
        }
    }
}
