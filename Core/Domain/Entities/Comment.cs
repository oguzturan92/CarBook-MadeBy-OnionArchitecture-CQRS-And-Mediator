using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentFullname { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}