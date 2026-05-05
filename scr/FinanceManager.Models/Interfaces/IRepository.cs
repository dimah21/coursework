namespace FinanceManager.Models.Interfaces;

public interface IRepository<T> where T : IEntity
{
    List<T> GetAll();
    T GetById(Guid id);
    void Create(T item);
    void Update(T item);
    void Delete(Guid id);

}