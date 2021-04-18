using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Service.impl
{
    public class CarService : ICarService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> GetList()
        {
            var data = await _context.Cars
                .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return data;
        }
    }
}