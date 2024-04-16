using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService;

public class IpraSortFilterPageOptions: SortFilterPageOptions
{
    public IpraFilterByStatus FilterByStatus { get; set; }

    public IpraFilterByEndless FilterByEndless { get; set; }

    protected override string GenerateCheckState()
    {
        return $"{FilterByStatus},{FilterByEndless},{PageSize},{NumPages}";
    }
}