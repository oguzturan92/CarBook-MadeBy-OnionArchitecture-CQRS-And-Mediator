using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontends.Dtos.AuthorDtos;
using Frontends.Dtos.CategoryDtos;

namespace Frontends.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string BlogDescription { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public List<ResultAuthorDto> ResultAuthorDtos { get; set; }
        public List<ResultCategoryDto> ResultCategoryDtos { get; set; }
    }
}