using DataLayer.Context;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService.Models;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService.Concrete;

/// <summary>
/// Класс ListIpraService предоставляет функционал для сортировки, фильтрации и постраничного вывода данных IpraListDto.
/// </summary>
public class ListIpraService
{
    private readonly IpraContext _context;

    /// <summary>
    /// Конструктор класса ListIpraService.
    /// </summary>
    /// <param name="context">Экземпляр контекста IpraContext.</param>
    public ListIpraService(IpraContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Метод SortFilterPage возвращает отсортированный и отфильтрованный список IpraListDto, разбитый на страницы.
    /// </summary>
    /// <param name="options">Параметры сортировки и фильтрации.</param>
    /// <returns>Отсортированный и отфильтрованный список IpraListDto, разбитый на страницы.</returns>
    public IQueryable<IpraListViewModel> SortFilterPage(IpraSortFilterPageOptions options)
    {
        // Создаем запрос, который будет использоваться для сортировки и фильтрации данных.
        IQueryable<IpraListViewModel> ipraQuery = _context.Ipras
            .AsNoTracking() // Отключаем отслеживание изменений объектов.
            .MapIpraToDto()
            .OrderBy(x => x.id)
            .FilterIpraByStatus(options.FilterByStatus) 
            .FilterIpraByEndless(options.FilterByEndless)
            .MapDtoToViewModel(); 

        // Устанавливаем дополнительные параметры для Dto.
        options.SetupRestOfDto(ipraQuery);

        var result = ipraQuery.Page(options.PageNum - 1, options.PageSize);
        // Возвращаем результат запроса, разбитый на страницы.
        return result;
    }
}