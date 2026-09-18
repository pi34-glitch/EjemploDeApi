using EjemploDeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploDeApi.Data;

public class RestaurantesDbContext : DbContext
{
    public RestaurantesDbContext(DbContextOptions<RestaurantesDbContext> options)
        : base(options) { }

    public DbSet<Restaurante> Restaurantes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Restaurante)
            .WithMany(rest => rest.Reservas)
            .HasForeignKey(r => r.IdRestaurante)
            .OnDelete(DeleteBehavior.Cascade);
    }
}