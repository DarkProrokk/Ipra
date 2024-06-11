using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Application.Dtos;

namespace IpraAspNet.Application.IpraService.Mappers;

public static partial class IpraMappers
{
    public static Expression<Func<Ipra, IpraListDto>> IpraToListDtoMapper()
    {
        return ipra => new IpraListDto
        {
            id = ipra.id,
            Number = ipra.Number,
            FirstName = ipra.PatientNameMse,
            Surname = ipra.PatientSurnameMse,
            Patronymic = ipra.PatientLastnameMse,
            Snils = ipra.PatientSnilsMse,
            Sector = ipra.SectorName,
            BirthDate = ipra.PatientBirthdayMse,
            MoShortName = ipra.Mo!.Shortname,
            StatusId = ipra.StatusId,
            StartDate = ipra.IssueDate,
            EndDate = ipra.EndDate,
            Report = ipra.Reports.Count,
            IsEndless = ipra.IsEndless
        };
    }
}