namespace CSC578Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using ViewModels;

    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext context;

        public BlogRepository(BlogContext context)
        {
            this.context = context;
        }

        public IQueryable<Post> GetPosts()
        {
            var posts = this.context.Posts.OrderBy(t => t.Created);
            return posts;
        }

        public Post GetPost(int id)
        {
            if(this.context.Posts.Any(p => p.Id == id))
            {
                return this.context.Posts.First(p => p.Id == id);
            }

            return null; 
        }

        public void RemoveTrip(int id)
        {
            if (this.context.Posts.Any(p => p.Id == id))
            {
                this.context.Remove(this.context.Posts.First(p => p.Id == id));
            }
        }

        public bool SaveAll()
        {
            return this.context.SaveChanges() > 0;
        }

        public void EditPost(Post updatedPost)
        {
            updatedPost.Edited = DateTime.UtcNow;
            this.context.Posts.Update(updatedPost);
        }

        public void AddPost(Post newPost)
        {
            newPost.Created = DateTime.UtcNow;
            this.context.Add(newPost);
        }

        public List<PostViewModel> GetPostViews()
        {
            var postViews = Mapper.Map<List<PostViewModel>>(this.GetPosts());
            return postViews.UserNames(this.context);
        }

        public IQueryable<Comment> GetCommentsByPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
