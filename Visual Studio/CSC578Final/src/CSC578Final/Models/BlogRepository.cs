using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final.Models
{
    using CSC578Final.Models;

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
