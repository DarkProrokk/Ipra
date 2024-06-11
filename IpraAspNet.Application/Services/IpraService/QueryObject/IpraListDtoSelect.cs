using IpraAspNet.Application.Dtos;
using IpraAspNet.Application.Services.IpraService.Models;
using IpraAspNet.Domain.Entities;

namespace IpraAspNet.Application.Services.IpraService.QueryObject;

public static class IpraListDtoSelect
{
    public static IEnumerable<IpraListViewModel> MapDtoToViewModel(this IEnumerable<IpraListDto> ipra)
    {
        return ipra.Select(item => new IpraListViewModel
        {
            Id = item.id,
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