namespace CSC578Final.Models
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Mvc;

    public class BlogRepository : IBlogRepository
    {
        [FromServices]
        public BlogRepository BlogContext { get; set; }

        public IQueryable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetCommentsByTopic(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
