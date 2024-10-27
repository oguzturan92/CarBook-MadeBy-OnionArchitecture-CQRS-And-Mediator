using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string CommentFullname { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentCreateDate { get; set; }
    }
}