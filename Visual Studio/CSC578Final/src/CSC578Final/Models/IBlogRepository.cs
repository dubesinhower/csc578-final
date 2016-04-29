namespace CSC578Final.Models
{
    using System.Linq;

    using CSC578Final.ViewModels;

    public interface IBlogRepository
    {
        IQueryable<PostViewModel> GetPosts();
        IQueryable<Comment> GetCommentsByTopic(int postId);
    }
}
