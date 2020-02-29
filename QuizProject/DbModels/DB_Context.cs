using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DbModels
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TCuestionario> TCuestionario { get; set; }
        public virtual DbSet<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
        public virtual DbSet<TOpcion> TOpcion { get; set; }
        public virtual DbSet<TPregunta> TPregunta { get; set; }
        public virtual DbSet<TRespuesta> TRespuesta { get; set; }
        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3N56573\\SQLEXPRESS;Database=QuizMaker; persist security info=True; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCuestionario>(entity =>
            {
                entity.ToTable("t_Cuestionario");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");

                entity.Property(e => e.Nombe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioCreaNavigation)
                    .WithMany(p => p.TCuestionario)
                    .HasForeignKey(d => d.IdUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Cuestionario_t_Usuario");
            });

            modelBuilder.Entity<TCuestionarioRegistro>(entity =>
            {
                entity.ToTable("t_CuestionarioRegistro");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdCuestionario).ValueGeneratedOnAdd();

                entity.Property(e => e.Puntaje).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithMany(p => p.TCuestionarioRegistro)
                    .HasForeignKey(d => d.IdCuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_CuestionarioRegistro_t_Cuestionario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TCuestionarioRegistro)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_CuestionarioRegistro_t_Usuario");
            });

            modelBuilder.Entity<TOpcion>(entity =>
            {
                entity.ToTable("t_Opcion");

                entity.Property(e => e.Etiqueta)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(6, 3)");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.TOpcion)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Opcion_t_Pregunta");
            });

            modelBuilder.Entity<TPregunta>(entity =>
            {
                entity.ToTable("t_Pregunta");

                entity.Property(e => e.IdCuestionario).HasColumnName("idCuestionario");

                entity.Property(e => e.IdTipoPregunta).HasColumnName("idTipoPregunta");

                entity.Property(e => e.Instrucciones).IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RangoMaximo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RangoMinimo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithMany(p => p.TPregunta)
                    .HasForeignKey(d => d.IdCuestionario)
                    .HasConstraintName("FK_t_Pregunta_t_Cuestionario");
            });

            modelBuilder.Entity<TRespuesta>(entity =>
            {
                entity.ToTable("t_Respuesta");

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(6, 3)");

                entity.HasOne(d => d.IdCuestionarioRegistroNavigation)
                    .WithMany(p => p.TRespuesta)
                    .HasForeignKey(d => d.IdCuestionarioRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Respuesta_t_CuestionarioRegistro");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.TRespuesta)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Respuesta_t_Pregunta");
            });

            modelBuilder.Entity<TTipoUsuario>(entity =>
            {
                entity.ToTable("t_TipoUsuario");

                entity.Property(e => e.Descriptor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.ToTable("t_Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Usuario_t_TipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
