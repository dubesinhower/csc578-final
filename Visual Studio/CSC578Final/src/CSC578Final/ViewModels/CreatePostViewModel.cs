namespace CSC578Final.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}