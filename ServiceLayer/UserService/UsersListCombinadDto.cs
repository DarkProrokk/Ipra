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
    public class UsersListCombinadDto(SortFilterPageOptions sortFilterPageData, IEnumerable<UsersListDto> usersList)
    {
        public SortFilterPageOptions SortFilterPageData { get; private set; } = sortFilterPageData;

        public IEnumerable<UsersListDto> UsersList { get; private set; } = usersList;
    }
}
