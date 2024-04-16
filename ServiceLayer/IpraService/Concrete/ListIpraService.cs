using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService.Concrete;
public class ListIpraService(IpraContext context)
{
    public IQueryable<IpraListDto> SortFilterPage(SortFilterPageOptions<IpraFilterBy> options)
    {
        var ipraQuery = context.Ipras
            .AsNoTracking()
            .MapIpraToDto()
            .OrderBy(x => x.id)
            .FilterIpraBy(options.FilterBy, options.FilterValue);

        options.SetupRestOfDto(ipraQuery);

        return ipraQuery.Page(options.PageNum - 1, options.PageSize);
    }
}
