using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogSubTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comments { get; set; }
    }
}