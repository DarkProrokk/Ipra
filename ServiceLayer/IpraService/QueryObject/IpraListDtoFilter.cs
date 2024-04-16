using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IpraService.QueryObject
{
    public enum IpraFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "By Open")] ByOpen,
        [Display(Name = "By Work")] ByWork,
        [Display(Name = "By Spent")] BySpent,
        [Display(Name = "By Close")] ByClose
    }

    public static class IpraListDtoFilter
    {
        public static IQueryable<IpraListDto> FilterIpraBy(this IQueryable<IpraListDto> ipra, IpraFilterBy filterBy,
            string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return ipra;
            switch (filterBy)
            {
                case IpraFilterBy.NoFilter:
                    return ipra;
                case IpraFilterBy.ByOpen:
                    return ipra.Where(i => i.StatusId == 1);
                case IpraFilterBy.ByWork:
                    return ipra.Where(i => i.StatusId == 1 && i.Report.Count > 0);
                case IpraFilterBy.BySpent:
                    return ipra.Where(i => i.StatusId == 2);
                case IpraFilterBy.ByClose:
                    int[] ClosedId = [3, 4, 5];
                    return ipra.Where(i => ClosedId.Contains(i.StatusId));
            }

            return ipra;
        }
    }
    
}
