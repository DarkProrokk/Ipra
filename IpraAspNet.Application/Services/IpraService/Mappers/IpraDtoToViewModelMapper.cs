using System.Linq.Expressions;
using IpraAspNet.Application.Dtos;
using IpraAspNet.Application.Services.IpraService.Models;

namespace IpraAspNet.Application.IpraService.Mappers;

public partial class IpraMappers
{
    public static Expression<Func<IpraListDto, IpraListViewModel>> ListDtoToViewModelMapper()
    {
        return item => new IpraListViewModel
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
        };
    }
}