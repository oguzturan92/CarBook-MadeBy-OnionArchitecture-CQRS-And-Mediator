using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.BlogRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogLast3WithAuthor();
    }
}