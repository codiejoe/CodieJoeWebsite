namespace CodieJoe.Web.Data.Repository.Interfaces;

public interface ICrudRepository<TEntity, TKey>
{
    Task<TEntity?> GetAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(TKey id);
}