using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudsByBlogId(int id);
    }
}