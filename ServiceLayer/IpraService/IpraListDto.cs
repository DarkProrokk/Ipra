using DataLayer.Entities;

namespace ServiceLayer.IpraService
{
    public class IpraListDto
    {
        public int id { get; set; }
        public required string Number { get; set;}

        public string? FirstName { get; set; }
        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? Snils { get; set; }

        public string? Sector { get; set; }
        public string? BirthDate { get; set; }
        public string? MoShortName { get; set; }
        public int StatusId { get; set; }
        public DateOnly? IssueDate { get; set; }
        public DateOnly? EndDate { get; set; }
        
        public ICollection<Report>? Report { get; set; }
    }
}
