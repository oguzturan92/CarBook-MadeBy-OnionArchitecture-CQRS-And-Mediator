using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.TagCloudInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;
        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
        {
            return await _context.TagClouds.Where(i => i.BlogId == id).ToListAsync();
        }
    }
}