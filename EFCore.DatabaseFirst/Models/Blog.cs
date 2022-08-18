using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.DatabaseFirst.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        //[MaxLength(300)]
        public string Url { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
