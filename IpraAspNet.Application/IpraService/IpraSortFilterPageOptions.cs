using IpraAspNet.Domain.QueryObjects;
using IpraAspNet.Application.IpraService.QueryObject;

namespace IpraAspNet.Application.IpraService;

public class IpraSortFilterPageOptions: SortFilterPageOptions
{
    public IpraFilterByStatus FilterByStatus { get; set; }

    public IpraFilterByEndless FilterByEndless { get; set; }

    protected override string GenerateCheckState()
    {
        return $"{FilterByStatus},{FilterByEndless},{PageSize},{NumPages}";
    }
}