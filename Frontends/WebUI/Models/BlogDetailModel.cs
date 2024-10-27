using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontends.Dtos.CategoryDtos;
using Dtos.TagCloudDtos;
using Frontends.Dtos.BlogDtos;

namespace WebUI.Models
{
    public class BlogDetailModel
    {
        public List<ResultCategoryDto> Categories { get; set; }
        public List<ResultBlogLast3Dto> Blogs { get; set; }
        public GetByIdBlogDto Blog { get; set; }
        public List<GetTagCloudByBlogIdDto> Tags { get; set; }
    }
}