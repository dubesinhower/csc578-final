using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final.Models
{
    using CSC578Final.Models;

    public interface IBlogRepository
    {
        IQueryable<Post> GetPosts();
        IQueryable<Comment> GetCommentsByTopic(int postId);
    }
}
