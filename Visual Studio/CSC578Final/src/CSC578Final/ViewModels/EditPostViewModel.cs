using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using CSC578Final.Models;

    public class EditPostViewModel
    {
        public EditPostViewModel()
        {
            
        }
        public EditPostViewModel(Post post)
        {
            this.Title = post.Title;
            this.Body = post.Body;
        }
        [Required]
        public int Id { get; set;}
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
