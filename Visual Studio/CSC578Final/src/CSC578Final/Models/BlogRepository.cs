namespace CSC578Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CSC578Final.ViewModels;

    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Mvc;

    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext context;

        public BlogRepository(BlogContext context)
        {
            this.context = context;
        }

        public IQueryable<PostViewModel> GetPosts()
        {
            var posts = this.context.Posts.PostToViewModel(this.context).OrderBy(t => t.Created);
            return posts;
        }

        public IQueryable<Comment> GetCommentsByTopic(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
