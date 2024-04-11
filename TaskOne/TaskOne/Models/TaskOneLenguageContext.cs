using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskOne.Models
{
    public partial class TaskOneLenguageContext : DbContext
    {
        public TaskOneLenguageContext()
        {
        }

        public TaskOneLenguageContext(DbContextOptions<TaskOneLenguageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;
        public virtual DbSet<TbUserCredential> TbUserCredentials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__tb_user__D2D146376D0472C7");

                entity.ToTable("tb_user");

                entity.HasIndex(e => e.CardUser, "UQ__tb_user__0C6299F7B361A940")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.CardUser)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("card_user");

                entity.Property(e => e.DirectionUser)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("direction_user");

                entity.Property(e => e.LastNameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name_user");

                entity.Property(e => e.NameCompleteUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_complete_user");

                entity.Property(e => e.PhoneNumberUser)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_user");
            });

            modelBuilder.Entity<TbUserCredential>(entity =>
            {
                entity.HasKey(e => e.IdCredential)
                    .HasName("PK__tb_user___E447A955DC2DB3BB");

                entity.ToTable("tb_user_credential");

                entity.Property(e => e.IdCredential).HasColumnName("id_credential");

                entity.Property(e => e.CardCredential)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("card_credential");

                entity.Property(e => e.PasswordCredential)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_credential");

                entity.HasOne(d => d.CardCredentialNavigation)
                    .WithMany(p => p.TbUserCredentials)
                    .HasPrincipalKey(p => p.CardUser)
                    .HasForeignKey(d => d.CardCredential)
                    .HasConstraintName("FK_card_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
