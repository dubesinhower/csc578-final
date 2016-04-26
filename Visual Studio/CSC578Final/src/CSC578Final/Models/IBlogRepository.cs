namespace CSC578Final.Models
{
    using System.Linq;

    public interface IBlogRepository
    {
        IQueryable<Post> GetPosts();
        IQueryable<Comment> GetCommentsByTopic(int postId);
    }
}
