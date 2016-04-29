namespace CSC578Final.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public DateTime Created { get; set; }
    }
}
