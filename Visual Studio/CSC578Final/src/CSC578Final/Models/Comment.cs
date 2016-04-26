namespace CSC578Final.Models
{
    using System;

    public class Comment
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string PostId { get; set; }
    }
}
