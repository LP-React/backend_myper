using backend_myper.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace backend_myper.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>(tb =>
            {
                tb.HasKey(col => col.TipoDocumentoId);
                tb.Property(col => col.TipoDocumentoId).ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).IsRequired().HasMaxLength(50);
                tb.ToTable("TipoDocumento");
                tb.HasData(
                    new TipoDocumento { TipoDocumentoId = 1, Nombre = "DNI" },
                    new TipoDocumento { TipoDocumentoId = 2, Nombre = "Pasaporte" }
                );
            });

            modelBuilder.Entity<Trabajador>(tb =>
            {
                tb.HasKey(col => col.TrabajadorId);
                tb.Property(col => col.TrabajadorId).ValueGeneratedOnAdd();
                tb.Property(col => col.Nombres).IsRequired().HasMaxLength(80);
                tb.Property(col => col.Apellidos).IsRequired().HasMaxLength(80);
                tb.HasOne(col => col.TipoDocumento).WithMany(t => t.Trabajadores).HasForeignKey(col => col.TipoDocumentoId);
                tb.ToTable("Trabajador");
            });
        }
    }
}




