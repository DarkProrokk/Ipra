using IpraAspNet.Domain.Enums;
using IpraAspNet.Domain.QueryObjects;

namespace IpraAspNet.Application.Services.IpraService;

public class IpraFilterOptions: FilterOptions
{
    public IpraFilterByStatus FilterByStatus { get; set; }

    public IpraFilterByEndless FilterByEndless { get; set; }
    
}