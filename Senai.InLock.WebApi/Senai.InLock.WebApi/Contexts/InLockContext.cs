using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.WebApi.Domains
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_InLock;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.EstudioId);

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK__Estudios__PaisId__4F7CD00D");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Estudios__Usuari__5070F446");
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasKey(e => e.JogoId);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estudio)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.EstudioId)
                    .HasConstraintName("FK__Jogos__EstudioId__534D60F1");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.PaisId);

                entity.Property(e => e.NomePais)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105342D8F4D10")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
