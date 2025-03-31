using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeslaReto.Data.IRepositories;
using TeslaReto.Data.Models;

namespace TeslaReto.Data.Repositories
{
    public class AutorRepository<TId, TEntity> : IAutorRepository<TId, TEntity>
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public AutorRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id)) ?? throw new KeyNotFoundException($"Entidad con ID {id} no encontrada.");
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TId id, TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var existingEntity = await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entidad con ID {id} no encontrada.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<TEntity> DeleteAsync(TId id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entidad con ID {id} no encontrada.");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

