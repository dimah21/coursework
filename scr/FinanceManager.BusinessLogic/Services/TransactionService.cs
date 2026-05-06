using FinanceManager.Models.Entities;
using FinanceManager.Models.Interfaces;
using FinanceManager.BusinessLogic.Delegates;

namespace FinanceManager.BusinessLogic.Services;

public class TransactionService
{
    private readonly IRepository<Transaction> _repository;

    public TransactionService(IRepository<Transaction> repository)
    {
        _repository = repository;
    }

    public void AddTransaction(Transaction transaction)
    {
        if (transaction.Amount <= 0)
        {
            throw new ArgumentException("Сума операції повинна бути більшою за нуль.");
        }

        if (transaction.Id == Guid.Empty)
        {
            transaction.Id = Guid.NewGuid();
        }
        
        _repository.Create(transaction);
    }

    public List<Transaction> GetAll()
    {
        return _repository.GetAll();
    }

    public List<Transaction> GetFiltered(TransactionFilter filterDelegate)
    {
        List<Transaction> allTransaction = _repository.GetAll();
        List<Transaction> filteredList = new List<Transaction>();

        foreach (Transaction transaction in allTransaction)
        {
            if (filterDelegate(transaction))
            {
                filteredList.Add(transaction);
            }
        }

        return filteredList;
    }

    public void DelegateTransaction(Guid id)
    {
        _repository.Delete(id);
    }
}