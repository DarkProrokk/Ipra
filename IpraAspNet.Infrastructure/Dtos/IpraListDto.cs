using IpraAspNet.Domain.Entities;

namespace IpraAspNet.Application.Dtos;

public class IpraListDto
{
    public int id { get; set; }
    public int StatusId { get; set; }
    public bool IsEndless { get; set; }
    public int? Report { get; set; }
    
    public required string Number { get; set; }

    public string? FirstName { get; set; }
    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Snils { get; set; }

    public string? Sector { get; set; }
    public string? BirthDate { get; set; }
    public string? MoShortName { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}