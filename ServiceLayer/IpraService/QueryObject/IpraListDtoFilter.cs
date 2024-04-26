using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using DataLayer.Entities;
using DataLayer.Extensions;
using ServiceLayer.IpraService.Models;

namespace ServiceLayer.IpraService.QueryObject;

public enum IpraFilterByStatus
{
    [Display(Name = "Все")] NoFilter = 0,
    [Display(Name = "Открытые")] ByOpen,
    [Display(Name = "В работе")] ByWork,
    [Display(Name = "Отработанные")] BySpent,
    [Display(Name = "Закрытые")] ByClose
}

public enum IpraFilterByEndless
{
    [Display(Name = "Все")] NoFilter = 0,
    [Display(Name = "Срок истекает")] Expiring,
    [Display(Name = "С датой оканчания")] WithEndDate,
    [Display(Name = "Без даты окончания")] Indefinitely
}


public static class IpraListDtoFilter
{
    /// <summary>
    /// Метод расширения для <see cref="IpraListDto"/>, для фильтрации по статусу.
    /// </summary>
    /// <param name="ipra">Объект <see cref="IpraListDto"/></param>
    /// <param name="filterBy">enum список фильтров <see cref="IpraFilterByStatus"/> </param>
    /// /// <returns>Отфильтрованный по статусу объект типа <see cref="IpraListDto"/></returns>
    public static IQueryable<IpraListDto> FilterIpraByStatus(this IQueryable<IpraListDto> ipra,
        IpraFilterByStatus filterBy)
    {
        switch (filterBy)
        {
            case IpraFilterByStatus.NoFilter:
                return ipra;
            case IpraFilterByStatus.ByOpen:
                return ipra.Where(i => i.StatusId == 1);
            case IpraFilterByStatus.ByWork:
                return ipra.Where(i => i.StatusId == 1 && i.Report.Count > 0);
            case IpraFilterByStatus.BySpent:
                return ipra.Where(i => i.StatusId == 2);
            case IpraFilterByStatus.ByClose:
                int[] ClosedId = [3, 4, 5];
                return ipra.Where(i => ClosedId.Contains(i.StatusId));
            default:
                throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
        }
    }
    /// <summary>
    /// Метод расширения для <see cref="IpraListDto"/>, для фильтрации по окончанию??.
    /// </summary>
    /// <param name="ipra">Объект <see cref="IpraListDto"/></param>
    /// <param name="filterBy">enum список фильтров <see cref="IpraFilterByEndless"/> </param>
    /// <returns>Отфильтрованный по окончанию?? объект типа <see cref="IpraListDto"/></returns>
    public static IQueryable<IpraListDto> FilterIpraByEndless(this IQueryable<IpraListDto> ipra, IpraFilterByEndless filterBy)
    {
        switch (filterBy)
        {
            case IpraFilterByEndless.NoFilter:
                return ipra;
            case IpraFilterByEndless.Expiring:
                return ipra;
            case IpraFilterByEndless.WithEndDate:
                return ipra.Where(s => !s.IsEndless);
            case IpraFilterByEndless.Indefinitely:
                return ipra.Where(s => s.IsEndless == true);
            default:
                throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
        }
    }

    public static IQueryable<IpraListDto> FilterIpraSearch(this IQueryable<IpraListDto> ipra, string? filterBy, string? filterValue)
    {
        if (filterBy is null || filterValue is null)
        {
            return ipra;
        }

        try
        {
            var expression = EqualFieldExtension.EqualField<IpraListDto>(filterBy, filterValue);
            return ipra.Where(expression);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}