namespace IpraAspNet.Application.Services.IpraService.Models;

public class IpraListViewModel
{
    public int Id { get; set; }
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