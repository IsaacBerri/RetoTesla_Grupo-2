using System;
using TeslaReto.Data.Models;

namespace TeslaReto.Data.IRepositories;

public interface IUsuarios<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    Task<IEnumerable<Usuarios>> GetUsuariosAsync();

    Task<TEntity> GetUsuarioAsync(string nombre);
    
}
