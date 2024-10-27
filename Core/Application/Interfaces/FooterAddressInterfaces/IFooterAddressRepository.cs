using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.FooterAddressInterfaces
{
    public interface IFooterAddressRepository
    {
        Task<FooterAddress> GetFirstOrDefault();
    }
}