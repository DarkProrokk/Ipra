using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService.Concrete
{
    public interface IListUsersService
    {
        public IQueryable<UsersListDto> SortFilterPage(UsersSortFilterPageOptions options);
    }
}
