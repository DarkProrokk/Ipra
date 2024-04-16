using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.QueryObjects;

public class SortFilterPageOptions<T> where T: struct, Enum
{
    public const int DefaultPageSize = 10; //default page size is 10

    //-----------------------------------------
    //Paging parts, which require the use of the method

    private int _pageNum = 1;

    private int _pageSize = DefaultPageSize;


    public T FilterBy { get; set; }


    public string FilterValue { get; set; }


    public int[] PageSizes = new[] { 5, DefaultPageSize, 20, 50, 100, 500, 1000 };

    public int PageNum
    {
        get { return _pageNum; }
        set { _pageNum = value; }
    }

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value; }
    }


    /// <summary>
    ///     This is set to the number of pages available based on the number of entries in the query
    /// </summary>
    public int NumPages { get; private set; }

    /// <summary>
    ///     This holds the state of the key parts of the SortFilterPage parts
    /// </summary>
    public string PrevCheckState { get; set; }


    public void SetupRestOfDto<T>(IQueryable<T> query)
    {
        NumPages = (int)Math.Ceiling(
            (double)query.Count() / PageSize);
        PageNum = Math.Min(
            Math.Max(1, PageNum), NumPages);

        var newCheckState = GenerateCheckState();
        if (PrevCheckState != newCheckState)
            PageNum = 1;

        PrevCheckState = newCheckState;
    }


    private string GenerateCheckState()
    {
        return $"{Convert.ToInt32(FilterBy)},{FilterValue},{PageSize},{NumPages}";
    }
}
