using System;
using System.Collections.Generic;
using TorneoDeFutbol.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TorneoDeFutbol.Domain;

namespace TorneoDeFutbol.Infrastructure.Context
{
    public partial class TorneoDeFutbolDbContext : DbContext
    {
        public TorneoDeFutbolDbContext()
        {
        }

        public TorneoDeFutbolDbContext(DbContextOptions<TorneoDeFutbolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<Profesion> Profesions { get; set; } = null!;
        public virtual DbSet<Torneo> Torneos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipo");

                entity.Property(e => e.CodigoPais)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("Profesion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTorneo>(entity =>
            {
                entity.ToTable("TipoTorneo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.ToTable("Torneo");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoTorneo)
                    .WithMany(p => p.Torneos)
                    .HasForeignKey(d => d.TipoTorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_37");
            });

            OnModelCreatingPartial(modelBuilder);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
