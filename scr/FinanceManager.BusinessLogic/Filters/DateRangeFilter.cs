namespace FinanceManager.BusinessLogic.Filters;
using FinanceManager.Models.Entities;

public class DateRangeFilter
{
    private DateTime _startDate;
    private DateTime _endDate;

    public DateRangeFilter(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public bool IsMatch(Transaction transaction)
    {
        if (transaction.Date >= _startDate && transaction.Date <= _endDate)
        {
            return true;
        }

        return false;
    }
}