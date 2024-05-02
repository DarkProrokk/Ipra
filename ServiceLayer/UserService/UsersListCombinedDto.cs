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
    public class UsersListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<UsersListDto> usersList)
    {
        public SortFilterPageOptions SortFilterPageData { get; private set; } = sortFilterPageData;

        public IEnumerable<UsersListDto> UsersList { get; private set; } = usersList;

        public Dictionary<string, string> HeadersList { get; private set; } = GetHeaders();
        public static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                { "id", "id" },
                { "userName", "Логин" },
                { "userRoleUsers", "Роли" },
                { "surname", "Фамилия" },
                { "name", "Имя" },
                { "patronymic", "Отчество" },
                { "post", "Должность" },
                { "userMOUsers", "МО" },
            };
        }
    }
}
