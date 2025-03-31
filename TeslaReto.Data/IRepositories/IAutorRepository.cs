using TeslaReto.Data.Models;

namespace TeslaReto.Data.IRepositories;

public interface IAutorRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity album);
    Task<TEntity> UpdateAsync(TId id, TEntity album);
    Task<TEntity> DeleteAsync(TId id);
}