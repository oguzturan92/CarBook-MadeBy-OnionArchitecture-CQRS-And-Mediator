using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.CarRepositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarWithBrand();
    }
}