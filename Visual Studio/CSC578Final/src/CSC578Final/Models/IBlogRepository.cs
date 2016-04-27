namespace CSC578Final.Models
{
    using System.Linq;

    public interface IBlogRepository
    {
        IQueryable<PostViewModel> GetPosts();
        IQueryable<Comment> GetCommentsByTopic(int postId);
    }
}
