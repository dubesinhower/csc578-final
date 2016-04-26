namespace CSC578Final.Models
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
