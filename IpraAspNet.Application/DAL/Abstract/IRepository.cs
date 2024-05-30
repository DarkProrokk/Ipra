namespace IpraAspNet.Application.DAL.Abstract;

public interface IRepository<T> : IDisposable
{
    public T? GetById(int id);
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public void Save();
}