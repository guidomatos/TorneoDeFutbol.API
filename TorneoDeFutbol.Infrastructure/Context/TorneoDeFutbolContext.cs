using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TorneoDeFutbol.Domain;

namespace TorneoDeFutbol.Infrastructure.Context
{
    public partial class TorneoDeFutbolContext : DbContext
    {
        public TorneoDeFutbolContext()
        {
        }

        public TorneoDeFutbolContext(DbContextOptions<TorneoDeFutbolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=TorneoDeFutbol; Integrated Security=yes;");
            }
        }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
