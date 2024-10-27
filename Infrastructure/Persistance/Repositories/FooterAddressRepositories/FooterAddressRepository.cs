using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FooterAddressInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.FooterAddressRepositories
{
    public class FooterAddressRepository : IFooterAddressRepository
    {
        private readonly CarBookContext _context;
        public FooterAddressRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<FooterAddress> GetFirstOrDefault()
        {
            return await _context.FooterAddresses.FirstOrDefaultAsync() ?? new FooterAddress();
        }
    }
}