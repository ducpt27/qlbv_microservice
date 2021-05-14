﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.Car
{
    public class PointsFilterReq : IRequest<List<CarDto>>
    {
        public class CarsFilterHandler : IRequestHandler<PointsFilterReq, List<CarDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CarsFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CarDto>> Handle(PointsFilterReq request, CancellationToken cancellationToken)
            {
                var carDtos = await _context.Cars
                    .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.Status != 2)
                    .ToListAsync(cancellationToken);
                return carDtos;
            }
        }
    }
}