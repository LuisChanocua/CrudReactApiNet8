using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CruedReactApiNet8.Models;

public partial class DbacrudReactnetapi8Context : DbContext
{
    public DbacrudReactnetapi8Context()
    {
    }

    public DbacrudReactnetapi8Context(DbContextOptions<DbacrudReactnetapi8Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9ED424F691");

            entity.ToTable("Empleado");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
