using ClassLibrary1.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ClassLibrary1.Data_Access.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    //TODO: do  I need to implement idisposable?

    protected readonly MyAppContext Context;

    public Repository(MyAppContext context) => Context = context;

    public TEntity? Get(int id) => Context.Set<TEntity>().Find(id);
    public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>().ToList();

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);
    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().SingleOrDefault(predicate);

    public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);
    public void AddRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().AddRange(entities);

    public void Remove(int id)
    {
        var entity = Get(id);
        if (entity is not null)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    public void RemoveRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);

    public void Save() => Context.SaveChanges();
}
