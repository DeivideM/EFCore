using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EFCore.DatabaseFirst.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        [DisplayName("Blog")]
        public int BlogId { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string Title { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
