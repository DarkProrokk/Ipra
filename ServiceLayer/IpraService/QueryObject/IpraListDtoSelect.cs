using DataLayer.Entities;

namespace ServiceLayer.IpraService.QueryObject
{
    public static class IpraListDtoSelect
    {
        public static IQueryable<IpraListDto> MapIpraToDto(this IQueryable<Ipra> ipra)
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
                MoShortName = item.Mo.Shortname,
                StatusId = item.StatusId,
                IssueDate = item.IssueDate,
                EndDate = item.EndDate,
                Report = item.Reports
            });
        }
    }
}
