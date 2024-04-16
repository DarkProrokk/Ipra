using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService
{
    public class IpraListCombinedDto(SortFilterPageOptions<IpraFilterBy> sortFilterPageData, IEnumerable<IpraListDto> ipraList)
    {
        public SortFilterPageOptions<IpraFilterBy> SortFilterPageData { get; private set; } = sortFilterPageData;

        public IEnumerable<IpraListDto> IpraList { get; private set;} = ipraList;
    }
}
