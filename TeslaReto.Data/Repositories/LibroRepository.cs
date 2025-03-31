using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeslaReto.Data.IRepositories;
using TeslaReto.Data.Models;

namespace TeslaReto.Data.Repositories
{
    public class LibroRepository<TId, TEntity> : ILibroRepository<TId, TEntity>
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public LibroRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<Libro>> SearchBooksAsync(
    string? titulo = null,
    int? autorId = null,
    string? genero = null,
    string? idioma = null,
    string? formato = null,
    int? anioPublicacion = null,
    string? editorial = null,
    string? isbn13 = null)
        {
            IQueryable<Libro> query = (IQueryable<Libro>)_dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo!));

            if (!string.IsNullOrEmpty(autorId.ToString()))
                query = query.Where(l => l.AuthorID.Equals(autorId));

            if (!string.IsNullOrEmpty(genero))
                query = query.Where(l => l.Genero.Contains(genero));

            if (!string.IsNullOrEmpty(idioma))
                query = query.Where(l => l.Idioma.Contains(idioma));

            if (!string.IsNullOrEmpty(formato))
                query = query.Where(l => l.Formato.Contains(formato));

            if (anioPublicacion.HasValue)
                query = query.Where(l => l.AnioPublicacion == anioPublicacion.Value);

            if (!string.IsNullOrEmpty(editorial))
                query = query.Where(l => l.Editorial.Contains(editorial));

            if (!string.IsNullOrEmpty(isbn13))
                query = query.Where(l => l.ISBN13 == isbn13);

            return await query.ToListAsync();
        }


        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> DeleteAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró el libro con ID: {id}");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<TEntity> UpdateAsync(TId id, TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"No se encontró el libro con ID: {id}");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
    }
}

