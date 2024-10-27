using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.BannerInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.BannerRepositories
{
    public class BannerRepository : IBannerRepository
    {
        private readonly CarBookContext _context;
        public BannerRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<Banner> GetFirstOrDefault()
        {
            return await _context.Banners.FirstOrDefaultAsync() ?? new Banner();
        }
    }
}