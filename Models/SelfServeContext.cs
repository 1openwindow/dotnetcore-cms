using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sky.SelfServe.Models
{
    public partial class SelfServeContext : DbContext
    {
        public SelfServeContext()
        {
        }

        public SelfServeContext(DbContextOptions<SelfServeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Template> Template { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasIndex(e => e.PartnerId)
                    .HasName("IDX_Partner");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TileImageUrl).HasMaxLength(256);

                entity.Property(e => e.TileLink).HasMaxLength(256);

                entity.Property(e => e.TileName).HasMaxLength(256);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasIndex(e => e.TemplateId)
                    .HasName("IDX_Template");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TileImageUrl).HasMaxLength(256);

                entity.Property(e => e.TileLink).HasMaxLength(256);

                entity.Property(e => e.TileName).HasMaxLength(256);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Url).HasMaxLength(256);
            });
        }
    }
}
