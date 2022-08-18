using System.ComponentModel;

namespace EFCore.CodeFirstMySQL.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDateTime { get; set; }
        [DisplayName("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
