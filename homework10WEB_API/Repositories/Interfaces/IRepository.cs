namespace homework10WEB_API.Repositories.Interfaces;

public interface IRepository<T>
{
    void Add(T data);
    void Remove(int id);
    List<T>? GetAll();
    T? GetById(int id);
}
