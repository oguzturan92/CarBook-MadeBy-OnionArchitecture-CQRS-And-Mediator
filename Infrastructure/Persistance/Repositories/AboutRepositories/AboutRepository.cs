using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.AboutInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.AboutRepositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly CarBookContext _context;
        public AboutRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<About> GetFirstOrDefault()
        {
            return await _context.Abouts.FirstOrDefaultAsync() ?? new About();
        }
    }
}