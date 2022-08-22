using EFCore.CodeFirst.Data.Map;
using EFCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.CodeFirst.Data
{
   public class EFCoreDBContext : DbContext
   {
      public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options)
          : base(options)
      {

      }

      public DbSet<Blog> Blogs { get; set; }
      public DbSet<Post> Posts { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new BlogMap());
         modelBuilder.ApplyConfiguration(new PostMap());
      }
   }
}
