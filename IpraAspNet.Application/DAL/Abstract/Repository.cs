using IpraAspNet.Domain.Context;
namespace IpraAspNet.Application.DAL.Abstract;

public abstract class Repository<T>(IpraContext context): IRepository<T> where T : class
{
    public T? GetById(int id)
    {
        return context.Set<T>().Find(id);
    }

    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
    }
    
    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }
    
    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public void Save()
    {
        context.SaveChanges();
    }
    
    private bool _disposed;
 
    protected virtual void Dispose(bool disposing)
    {
        if(_disposed)
        {
            if(disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
}