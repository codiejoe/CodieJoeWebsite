using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodieJoe.Web.Data.Repository.Implementations;

public class CrudRepository<TEntity, TKey>
    : ICrudRepository<TEntity, TKey> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public CrudRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
            return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}