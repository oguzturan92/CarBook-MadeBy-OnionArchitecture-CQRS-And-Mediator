using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.BlogInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogByIdWithAuthor(int id)
        {
            return await _context.Blogs.Where(x => x.BlogId == id).Include(x => x.Author).FirstOrDefaultAsync();
        }

        public async Task<List<Blog>> GetBlogLast3WithAuthor()
        {
            return await _context.Blogs.OrderByDescending(x => x.BlogId).Take(3).Include(x => x.Author).ToListAsync();
        }
    }
}