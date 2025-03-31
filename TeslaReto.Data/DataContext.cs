using Microsoft.EntityFrameworkCore;
using TeslaReto.Data.Models;

namespace TeslaReto.Data;

public class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Autor> Autores  { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<AudioLibros> AudioLibros { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder == null)
        {
            return;
        }

        

        builder.Entity<Autor>().ToTable("Autor").HasKey(a => a.Id);
        builder.Entity<Libro>().ToTable("Libro").HasKey(a => a.Id);
        builder.Entity<AudioLibros>().ToTable("AudioLibros").HasKey(a => a.Id);

        base.OnModelCreating(builder);
    }
}
