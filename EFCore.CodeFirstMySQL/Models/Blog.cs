﻿namespace EFCore.CodeFirstMySQL.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
