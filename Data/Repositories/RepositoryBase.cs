using Data;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
  public class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    public RepositoryContext _repositoryContext { get; }

    public RepositoryBase(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public T Create(T entity) 
    {
        var createdEntity = _repositoryContext.Set<T>().Add(entity);
        _repositoryContext.SaveChanges();
        return createdEntity.Entity;
    }

    public void Delete(T entity)
    {
      _repositoryContext.Set<T>().Remove(entity);
      _repositoryContext.SaveChanges();
    }

    public virtual IQueryable<T> FindAll() => _repositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression) => 
      _repositoryContext.Set<T>().Where(expression).AsNoTracking();

    public void Update(T entity)
    {
      _repositoryContext.Set<T>().Update(entity);
      _repositoryContext.SaveChanges();
    }
  }
}