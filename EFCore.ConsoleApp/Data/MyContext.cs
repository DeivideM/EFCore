using EFCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ConsoleApp.Data
{
   public class MyContext : DbContext
   {
      public MyContext(DbContextOptions<MyContext> options)
         : base(options)
      {

      }

      public DbSet<Person> People { get; set; }

   }
}
