using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Eventos_Peru.Core.Core.Entities;

namespace Eventos_Peru.Core.Infrastructure.Data;

public partial class EventosPeruIaContext : DbContext
{
    public EventosPeruIaContext()
    {
    }

    public EventosPeruIaContext(DbContextOptions<EventosPeruIaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<CheckIn> CheckIn { get; set; }

    public virtual DbSet<Compra> Compra { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }

    public virtual DbSet<Entrada> Entrada { get; set; }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Interes> Interes { get; set; }

    public virtual DbSet<Moderacion> Moderacion { get; set; }

    public virtual DbSet<Notificacion> Notificacion { get; set; }

    public virtual DbSet<Resena> Resena { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioInteres> UsuarioInteres { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.HasIndex(e => e.Nombre, "UQ_Categoria_Nombre").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Estado).HasDefaultValue(true, "DF_Categoria_Estado");
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.IdCheckIn);

            entity.HasIndex(e => e.IdEntrada, "UQ_CheckIn_Entrada").IsUnique();

            entity.Property(e => e.FechaHora).HasDefaultValueSql("(sysdatetime())", "DF_CheckIn_Fecha");

            entity.HasOne(d => d.IdEntradaNavigation).WithOne(p => p.CheckIn)
                .HasForeignKey<CheckIn>(d => d.IdEntrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckIn_Entrada");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra);

            entity.HasIndex(e => e.IdUsuario, "IX_Compra_IdUsuario");

            entity.HasIndex(e => e.CodigoOperacion, "UQ_Compra_CodigoOperacion").IsUnique();

            entity.Property(e => e.CodigoOperacion).HasDefaultValueSql("(newid())", "DF_Compra_CodigoOperacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente", "DF_Compra_Estado");
            entity.Property(e => e.FechaCompra).HasDefaultValueSql("(sysdatetime())", "DF_Compra_Fecha");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compra)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Usuario");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra);

            entity.HasIndex(e => e.IdCompra, "IX_DetalleCompra_IdCompra");

            entity.HasIndex(e => e.IdEvento, "IX_DetalleCompra_IdEvento");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompra)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Compra");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.DetalleCompra)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Evento");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.IdEntrada);

            entity.HasIndex(e => e.IdDetalleCompra, "IX_Entrada_IdDetalleCompra");

            entity.HasIndex(e => e.CodigoEntrada, "UQ_Entrada_Codigo").IsUnique();

            entity.Property(e => e.CodigoEntrada).HasDefaultValueSql("(newid())", "DF_Entrada_Codigo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Valida", "DF_Entrada_Estado");
            entity.Property(e => e.FechaGeneracion).HasDefaultValueSql("(sysdatetime())", "DF_Entrada_Fecha");

            entity.HasOne(d => d.IdDetalleCompraNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdDetalleCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entrada_DetalleCompra");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento);

            entity.HasIndex(e => e.Estado, "IX_Evento_Estado");

            entity.HasIndex(e => e.FechaHoraInicio, "IX_Evento_FechaHoraInicio");

            entity.HasIndex(e => e.IdCategoria, "IX_Evento_IdCategoria");

            entity.HasIndex(e => e.IdOrganizador, "IX_Evento_IdOrganizador");

            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValue("Borrador", "DF_Evento_Estado");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())", "DF_Evento_FechaCreacion");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ubicacion).HasMaxLength(250);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Evento)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evento_Categoria");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Evento)
                .HasForeignKey(d => d.IdOrganizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evento_Organizador");
        });

        modelBuilder.Entity<Interes>(entity =>
        {
            entity.HasKey(e => e.IdInteres);

            entity.HasIndex(e => e.Nombre, "UQ_Interes_Nombre").IsUnique();

            entity.Property(e => e.Estado).HasDefaultValue(true, "DF_Interes_Estado");
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<Moderacion>(entity =>
        {
            entity.HasKey(e => e.IdModeracion);

            entity.HasIndex(e => e.IdAdministrador, "IX_Moderacion_Administrador");

            entity.Property(e => e.Accion).HasMaxLength(30);
            entity.Property(e => e.FechaAccion).HasDefaultValueSql("(sysdatetime())", "DF_Moderacion_Fecha");
            entity.Property(e => e.Motivo).HasMaxLength(500);

            entity.HasOne(d => d.IdAdministradorNavigation).WithMany(p => p.ModeracionIdAdministradorNavigation)
                .HasForeignKey(d => d.IdAdministrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Moderacion_Administrador");

            entity.HasOne(d => d.IdEventoAfectadoNavigation).WithMany(p => p.Moderacion)
                .HasForeignKey(d => d.IdEventoAfectado)
                .HasConstraintName("FK_Moderacion_Evento");

            entity.HasOne(d => d.IdUsuarioAfectadoNavigation).WithMany(p => p.ModeracionIdUsuarioAfectadoNavigation)
                .HasForeignKey(d => d.IdUsuarioAfectado)
                .HasConstraintName("FK_Moderacion_Usuario");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion);

            entity.HasIndex(e => new { e.IdUsuario, e.Leida }, "IX_Notificacion_Usuario");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())", "DF_Notificacion_Fecha");
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.Tipo).HasMaxLength(30);
            entity.Property(e => e.Titulo).HasMaxLength(150);

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Notificacion)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK_Notificacion_Evento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacion)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificacion_Usuario");
        });

        modelBuilder.Entity<Resena>(entity =>
        {
            entity.HasKey(e => e.IdResena);

            entity.HasIndex(e => e.IdEvento, "IX_Resena_IdEvento");

            entity.HasIndex(e => new { e.IdUsuario, e.IdEvento }, "UQ_Resena_UsuarioEvento").IsUnique();

            entity.Property(e => e.Comentario).HasMaxLength(500);
            entity.Property(e => e.FechaPublicacion).HasDefaultValueSql("(sysdatetime())", "DF_Resena_Fecha");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Resena)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resena_Evento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Resena)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resena_Usuario");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.HasIndex(e => e.Nombre, "UQ_Rol_Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.HasIndex(e => e.Correo, "UQ_Usuario_Correo").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo", "DF_Usuario_Estado");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF_Usuario_FechaRegistro");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
        });

        modelBuilder.Entity<UsuarioInteres>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdInteres });

            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF_UsuarioInteres_Fecha");

            entity.HasOne(d => d.IdInteresNavigation).WithMany(p => p.UsuarioInteres)
                .HasForeignKey(d => d.IdInteres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioInteres_Interes");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioInteres)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioInteres_Usuario");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdRol });

            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("(sysdatetime())", "DF_UsuarioRol_Fecha");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRol)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRol)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
