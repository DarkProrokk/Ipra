using ServiceLayer.IpraService.QueryObject;
using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.UserService.QueryObject
{
    public static class DataFilter
    {
        public static IQueryable<UsersListDto> FilterUsersBySearchString(this IQueryable<UsersListDto> users, string? searchString)
        {
            if (searchString is null)
                return users;

            // "\W" Это метасимвол, который соответствует любому символу, который не является буквой, цифрой или знаком подчеркивания
            // "+" Этот символ означает "один или более повторений предыдущего элемента"
            string[] searchWords = Regex.Split(searchString, @"\W+");

            IQueryable<UsersListDto> filteredUsersData = users;

            foreach (var word in searchWords.Where(w => !string.IsNullOrWhiteSpace(w)))
            {
                string tempWord = word.ToLower();
                filteredUsersData = filteredUsersData.Where(u =>
                    u.UserName != null && u.UserName.ToLower().Contains(tempWord) ||
                    u.Name != null && u.Name.ToLower().Contains(tempWord) ||
                    u.Surname != null && u.Surname.ToLower().Contains(tempWord) ||
                    u.Patronymic != null && u.Patronymic.ToLower().Contains(tempWord) ||
                    u.Post != null && u.Post.ToLower().Contains(tempWord) ||
                    u.UserMOUsers.Any(mo => mo.MO != null && mo.MO.Shortname.ToLower().Contains(tempWord)) ||
                    u.UserRoleUsers.Any(role => role.Role != null && role.Role.RoleDescription.ToLower().Contains(tempWord))
                );
            }

            return filteredUsersData;
        }
    }
}
