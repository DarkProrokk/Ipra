using DataLayer.Entities;
using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// Возвращает отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.
        /// </summary>
        /// <param name="options">Параметры сортировки и фильтрации.</param>
        /// <returns>Отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.</returns>
        public IQueryable<UsersListDto> GetSortedFilteredPage(UsersSortFilterPageOptions options);


        /// <summary>
        /// Возвращает информацию о пользователе, подходящуюю для страницы изменения данных пользователя
        /// </summary>
        /// <returns>Пользователь, найденный по userId</returns>
        public UserDto GetUserForUpdatePage(int userId);
    }
}
