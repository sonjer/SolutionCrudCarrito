using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PracticaCrud.Models;

namespace PracticaCrud.DAL.DataContext;

public partial class PracticaCarritoContext : DbContext
{
    public PracticaCarritoContext()
    {
    }

    public PracticaCarritoContext(DbContextOptions<PracticaCarritoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }

    public virtual DbSet<Artículo> Artículos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticuloTiendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3214EC27B9537B97");

            entity.ToTable("Articulo_Tienda");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.TiendaId).HasColumnName("TiendaID");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.ArticuloId)
                .HasConstraintName("FK__Articulo___Artic__2A4B4B5E");

            entity.HasOne(d => d.Tienda).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.TiendaId)
                .HasConstraintName("FK__Articulo___Tiend__2B3F6F97");
        });

        modelBuilder.Entity<Artículo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Artículo__D68C8CB11F9956C4");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC271C1AE6FD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dirección)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente___3214EC2791202398");

            entity.ToTable("Cliente_Articulo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.ArticuloId)
                .HasConstraintName("FK__Cliente_A__Artic__2F10007B");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Cliente_A__Clien__2E1BDC42");
        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tienda__3214EC27A0C49707");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dirección)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
