using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final.Models
{
    using CSC578Final.Models;

    using Microsoft.Data.Entity;

    public class BlogContext : DbContext
    {
        public BlogContext() { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
