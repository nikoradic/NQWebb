using Microsoft.EntityFrameworkCore;
using NQWebb.Data;
using System.Linq.Expressions;

namespace NQWebb.Helpers.Repositories;

public abstract class Repo<Entity> where Entity : class
{
    private readonly ApplicationDbContext _db;
    protected Repo(ApplicationDbContext db)
    {
        _db = db;
    }

    public virtual async Task<Entity> AddAsync(Entity entity)
    {
        await _db.Set<Entity>().AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }


    public virtual async Task<Entity> GetAsync(Expression<Func<Entity, bool>> expression)
    {
        var entity = await _db.Set<Entity>().FirstOrDefaultAsync(expression);
        return entity!;
    }


    public virtual async Task<IEnumerable<Entity>> GetAllAsync()
    {
        return await _db.Set<Entity>().ToListAsync();

    }
    public virtual async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> expression)
    {
        return await _db.Set<Entity>().Where(expression).ToListAsync();

    }


    public virtual async Task<Entity> UpdateAsync(Entity entity)
    {
        _db.Set<Entity>().Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public virtual async Task RemoveAsync(Entity entity)
    {
        _db.Set<Entity>().Remove(entity);
        await _db.SaveChangesAsync();

    }
}
