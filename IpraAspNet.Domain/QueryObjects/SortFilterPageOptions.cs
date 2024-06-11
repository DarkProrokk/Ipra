namespace IpraAspNet.Domain.QueryObjects;

/// <summary>
/// Базовый объект для сортировки, пагинации и фильтрации страниц
/// </summary>
public class SortFilterPageOptions
{
    /// <summary>
    /// default page size is 10
    /// </summary>
    private const int DefaultPageSize = 10;

    /// <summary>
    /// вариативность размера страницы
    /// </summary>
    public int[] PageSizes = { 5, DefaultPageSize, 20, 50, 100, 500, 1000 };

    /// <summary>
    /// Номер страницы, по-умолчанию - 1
    /// </summary>
    public int PageNum { get; set; } = 1; 

    public int PageSize { get; set; } = DefaultPageSize;


    /// <summary>
    ///    Количество страниц
    /// </summary>
    public int TotalNumPages { get; private set; }
    
    public int TotalNumNotes { get; private set; }

    public string? FilterBy { get; set; }

    public string? FilterValue { get; set; }

    /// <summary>
    ///     Сохраняет состояние ключевых частей частей SortFilterPage
    /// </summary>
    public string? PrevCheckState { get; set; }

    /// <summary>
    /// Метод генирирует кол-во доступных страниц исходя из размера страницы и кол-ва записей
    /// и генирирует строку состояния
    /// </summary>
    /// <typeparam name="T">Коллекция на основе которой нужно произвести расчёт</typeparam>
    /// <param name="query"></param>
    public void SetupRestOfDto<T>(IEnumerable<T> query)
    {
        TotalNumNotes = query.Count();

        TotalNumPages = (int)Math.Ceiling(
            (double)TotalNumPages / PageSize);
        PageNum = Math.Min(
            Math.Max(1, PageNum), TotalNumPages);

        var newCheckState = GenerateCheckState();
        //if (PrevCheckState != newCheckState)
        //    PageNum = 1;

        PrevCheckState = newCheckState;
    }
    public void SetupTestOfDto()
    {
        var newCheckState = GenerateCheckState();
        if (PrevCheckState != newCheckState)
            PageNum = 1;

        PrevCheckState = newCheckState;
    }
    protected virtual string GenerateCheckState()
    {
        return $"{PageSize},{TotalNumPages}";
    }
}