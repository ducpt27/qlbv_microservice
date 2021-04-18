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
    public class RouteService : IRouteService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RouteService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RouteDto>> GetList()
        {
            var data = await _context.Route
                .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return data;
        }
    }
}