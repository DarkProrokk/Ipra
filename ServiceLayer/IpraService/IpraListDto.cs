using DataLayer.Entities;
using ServiceLayer.IpraService.Models;

namespace ServiceLayer.IpraService;

public class IpraListDto: IpraListViewModel
{
    public int id { get; set; }
    public int StatusId { get; set; }
    public bool IsEndless { get; set; }
    public ICollection<Report>? Report { get; set; }
}