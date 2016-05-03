namespace CSC578Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Post
    {
        public Post()
        {
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
