using IpraAspNet.Domain.Entities;
using IpraAspNet.Application.IpraService.Models;

namespace IpraAspNet.Application.IpraService.QueryObject;

public static class IpraListDtoSelect
{
    /// <summary>
    /// Метод расширения для преобразования объектов типа <see cref="Ipra"/> в объекты типа <see cref="IpraListDto"/>.
    /// </summary>
    /// <param name="ipra">Коллекция объектов типа <see cref="Ipra"/>.</param>
    /// <returns>Объект типа IQueryable <see cref="IpraListDto"/></returns>
    public static IQueryable<IpraListDto> MapIpraToDto(this IQueryable<Domain.Entities.Ipra> ipra)
    {
        return ipra.Select(item => new IpraListDto
        {
            id = item.id,
            Number = item.Number,
            FirstName = item.PatientNameMse,
            Surname = item.PatientSurnameMse,
            Patronymic = item.PatientLastnameMse,
            Snils = item.PatientSnilsMse,
            Sector = item.SectorName,
            BirthDate = item.PatientBirthdayMse,
            MoShortName = item.Mo!.Shortname,
            StatusId = item.StatusId,
            StartDate = item.IssueDate,
            EndDate = item.EndDate,
            Report = item.Reports,
            IsEndless = item.IsEndless,
        });
    }

    public static IQueryable<IpraListViewModel> MapDtoToViewModel(this IQueryable<IpraListDto> ipra)
    {
        return ipra.Select(item => new IpraListViewModel
        {
            Number = item.Number,
            FirstName = item.FirstName,
            Surname = item.Surname,
            Patronymic = item.Patronymic,
            Snils = item.Snils,
            Sector = item.Sector,
            BirthDate = item.BirthDate,
            MoShortName = item.MoShortName,
            StartDate = item.StartDate,
            EndDate = item.EndDate
        });
    }
}