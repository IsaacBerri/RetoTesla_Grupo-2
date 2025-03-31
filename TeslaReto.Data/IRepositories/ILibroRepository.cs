using System.Linq.Expressions;
using TeslaReto.Data.Models;

namespace TeslaReto.Data.IRepositories;

public interface ILibroRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    Task<IEnumerable<Libro>> SearchBooksAsync(
        string? titulo = null,
        int? autorId = null,
        string? genero = null,
        string? idioma = null,
        string? formato = null,
        int? anioPublicacion = null,
        string? editorial = null,
        string? isbn13 = null
    );
    Task AddAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TId id);
    Task<TEntity> UpdateAsync(TId id, TEntity entity);
    
}
