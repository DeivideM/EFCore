using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ConsoleApp.Models
{
   [Table("Person")]
   [Index(nameof(UserName), IsUnique = true, Name = "IX_Username_Person")]
   //[Index(nameof(UserName), nameof(LastName))]
   public class Person
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column(Order = 0)]
      public Guid Id { get; set; }

      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      [Column(Order = 1)]
      [Required]
      public int PersonId { get; set; }

      [Required(ErrorMessage = "UserName is mandatory")]
      [StringLength(50)]
      [Unicode(false)]
      public string UserName { get; set; }

      [Unicode(false)]
      [Required]
      [MaxLength(300)]
      public string FirstName { get; set; }

      [Required]
      [Unicode(false)]
      [MaxLength(300)]
      public string LastName { get; set; }

      [NotMapped]
      public string FullName => string.Format($"{FirstName} {LastName}");

      [DataType(DataType.Password)]
      [Unicode(false)]
      [Required]
      public string Password { get; set; }

      [Unicode(false)]
      [Required]
      [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
      public string ConfirmPassword { get; set; }
      public DateTime DateCreated { get; set; }

      [DataType(DataType.EmailAddress)]
      public string Email { get; set; }

   }
}
