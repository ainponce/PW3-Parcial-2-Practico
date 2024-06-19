using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestionDeEquipos.datos.EF;

public partial class Pw3dbContext : DbContext
{
    public Pw3dbContext()
    {
    }

    public Pw3dbContext(DbContextOptions<Pw3dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Jugador> Jugadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=pw3db; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo).HasName("PK__Equipo__D805240859406992");

            entity.ToTable("Equipo");

            entity.Property(e => e.NombreEquipo).HasMaxLength(100);
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.IdJugador).HasName("PK__Jugador__99E32016A58EBB02");

            entity.ToTable("Jugador");

            entity.Property(e => e.NombreCompleto).HasMaxLength(100);

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Jugadors)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jugador_Equipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
