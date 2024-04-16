using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;
using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService
{
    public class UsersListCombinadDto(SortFilterPageOptions<IpraFilterBy> sortFilterPageData, IEnumerable<UsersListDto> usersList)
    {
        public SortFilterPageOptions<IpraFilterBy> SortFilterPageData { get; private set; } = sortFilterPageData;

        public IEnumerable<UsersListDto> UsersList { get; private set; } = usersList;
    }
}
