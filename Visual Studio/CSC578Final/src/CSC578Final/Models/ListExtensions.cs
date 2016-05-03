using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final
{
    using CSC578Final.Models;
    using CSC578Final.ViewModels;

    public static class ListExtensions
    {
        public static List<PostViewModel> UserNames(this List<PostViewModel> posts, BlogContext context)
        {
            foreach (var post in posts)
            {
                post.AuthorName = context.Users.SingleOrDefault(u => u.Id == post.AuthorId).UserName;
            }
            return posts;
        }
    }
}
