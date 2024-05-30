using IpraAspNet.Domain.Entities;
using IpraAspNet.Application.IpraService.Models;

namespace IpraAspNet.Application.IpraService;

public class IpraListDto: IpraListViewModel
{
    public int id { get; set; }
    public int StatusId { get; set; }
    public bool IsEndless { get; set; }
    public ICollection<Report>? Report { get; set; }
}