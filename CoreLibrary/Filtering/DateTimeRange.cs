namespace CoreLibrary.Filtering;

public readonly struct DateTimeRange
{
    private readonly DateTime _startDate, _endDate;
    
    public DateTimeRange(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public bool InRange(DateTime dt) => dt >= _startDate && dt <= _endDate;
}