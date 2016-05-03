namespace CSC578Final.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using CSC578Final.ViewModels;

    public interface IBlogRepository
    {
        IQueryable<Post> GetPosts();

        IQueryable<Comment> GetCommentsByPost(int id);

        Post GetPost(int id);

        void RemoveTrip(int id);

        bool SaveAll();

        void EditPost(Post post);

        void AddPost(Post newPost);

        List<PostViewModel> GetPostViews();
    }
}
