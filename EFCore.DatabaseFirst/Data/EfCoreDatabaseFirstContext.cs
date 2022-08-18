using System;
using System.Collections.Generic;
using EFCore.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.DatabaseFirst.Data
{
    public partial class EfCoreDatabaseFirstContext : DbContext
    {
        public EfCoreDatabaseFirstContext()
        {
        }

        public EfCoreDatabaseFirstContext(DbContextOptions<EfCoreDatabaseFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=localhost;Database=EfCoreDatabaseFirst;Trusted_Connection=True;MultipleActiveResultSets=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

            });

            modelBuilder.Entity<Blog>()
                .Property(t => t.Url)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(300);
            
            //.HasColumnType("varchar")
            //.HasDefaultValueSql("XXXX");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.BlogId, "IX_Post_BlogId");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
