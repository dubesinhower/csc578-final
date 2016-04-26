namespace CSC578Final.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Data.Entity;

    public sealed class BlogContext : IdentityDbContext<BlogUser>
    {
        public BlogContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
