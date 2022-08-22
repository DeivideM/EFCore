using EFCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCore.CodeFirst.Data.Map
{
   public class BlogMap : IEntityTypeConfiguration<Blog>
   {
      public void Configure(EntityTypeBuilder<Blog> builder)
      {
         builder.ToTable("Blog");

         builder.Property(a => a.Url)
            .HasMaxLength(350)
            .IsUnicode(false);

      }
   }
}
