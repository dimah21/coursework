namespace FinanceManager.DataAccess.Repositories;
using System.Text.Json;
using FinanceManager.DataAccess.Exceptions;
using FinanceManager.Models.Interfaces;

public class JsonRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly string _filePath;

    public JsonRepository(string filePath)
    {
        _filePath = filePath;
    }

    public List<T> GetAll()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            List<T> data = JsonSerializer.Deserialize<List<T>>(json);

            if (data != null)
            {
                return data;
            }
            else
            {
                return new List<T>();
            }
        }
        catch (Exception ex)
        {
            throw new DataAccessException($"Не вдалося прочитати дані з файлу: {_filePath}", ex);
        }
    }

    public T GetById(Guid id)
    {
        List<T> items = GetAll();

        foreach (T item in items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }

    public void Create(T item)
    {
        List<T> items = GetAll();
        items.Add(item);
        SaveChanges(items);
    }
    
    public void Update(T item)
    {
        List<T> items = GetAll();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == item.Id)
            {
                items[i] = item;
                break;
            }
        }
        
        SaveChanges(items);
    }
    
    public void Delete(Guid id)
    {
        List<T> items = GetAll();
        int indexToRemove = -1;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == id)
            {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove != -1)
        {
            items.RemoveAt(indexToRemove);
            SaveChanges(items);
        }
    }

    private void SaveChanges(List<T> items)
    {
        try
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            throw new DataAccessException($"Не вдалося зберегти дані у файл: {_filePath}", ex);
        }
    }
}
