namespace FinanceManager.BusinessLogic.Filters;
using FinanceManager.Models.Enums;
using FinanceManager.Models.Entities;
    
public class TypeFilter
{
    private TransactionType _targetType;

    public TypeFilter(TransactionType targetType)
    {
        _targetType = targetType;
    }

    public bool IsMatch(Transaction transaction)
    {
        if (transaction.Type == _targetType)
        {
            return true;
        }

        return false;
    }
}