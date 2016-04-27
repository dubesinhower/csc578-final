using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final
{
    using CSC578Final.Models;

    public static class QueryableExtensions
    {
        public static IQueryable<PostViewModel> PostToViewModel(this IQueryable<Post> query, BlogContext context)
        {
            return
                query.Select(
                    p =>
                    new PostViewModel()
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Body = p.Body,
                            AuthorName = context.Users.SingleOrDefault(u => u.Id == p.AuthorId).UserName,
                            Created = p.Created
                        });
        }
    }
}
