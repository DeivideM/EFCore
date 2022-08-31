using EFCore.ConsoleApp.Data;
using EFCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

var options = new DbContextOptionsBuilder<MyContext>()
   .UseInMemoryDatabase(databaseName: "Test")
   .Options;

using (var context = new MyContext(options))
{
   var person = new Person
   {
      PersonId = 1,
      UserName = "dvdmartins",
      FirstName = "Deivide",
      LastName = "Martins",
      Password = "@@xpto",
      ConfirmPassword = "@@xpto",
      DateCreated = DateTime.Now,
      Email = "deivide_martins@hotmail.com"
   };
   context.People.Add(person);
   context.SaveChanges();

   var people = context.People;
   foreach (var item in people)
   {
      Console.WriteLine(item.FullName);
   }
}

//Console.WriteLine("Hello, World!");
