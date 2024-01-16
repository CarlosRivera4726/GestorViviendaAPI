using Microsoft.EntityFrameworkCore;
using GestorViviendaAPI.Models;

namespace GestorViviendaAPI.Data;

public class GestorViviendaContext : DbContext
{
    public GestorViviendaContext(DbContextOptions<GestorViviendaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(u => u.uuid);
        modelBuilder.Entity<Usuario>().Property(u => u.nombre).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.apellido).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.email).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Usuario>().HasIndex(u => u.email).IsUnique();
        modelBuilder.Entity<Usuario>().Property(u => u.genero).HasMaxLength(50);
        modelBuilder.Entity<Usuario>().Property(u => u.clave).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.es_vendedor).HasDefaultValue(false);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
}