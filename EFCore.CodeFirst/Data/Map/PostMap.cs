using EFCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCore.CodeFirst.Data.Map
{
   public class PostMap : IEntityTypeConfiguration<Post>
   {
      public void Configure(EntityTypeBuilder<Post> builder)
      {
         builder.ToTable("Post");

         builder.Property(a => a.Title)
            .HasMaxLength(350)
            .IsRequired(true)
            .IsUnicode(false);

         builder.Property(a => a.Content)
            .HasMaxLength(400)
            .IsUnicode(false);
      }
   }
}
