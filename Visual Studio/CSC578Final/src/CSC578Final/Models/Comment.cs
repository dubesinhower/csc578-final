namespace CSC578Final.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public int PostId { get; set; }
    }
}
