using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.BannerInterfaces
{
    public interface IBannerRepository
    {
        Task<Banner> GetFirstOrDefault();
    }
}