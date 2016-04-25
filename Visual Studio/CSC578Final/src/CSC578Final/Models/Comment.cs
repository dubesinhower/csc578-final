using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC578Final.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public int PostId { get; set; }
    }
}
